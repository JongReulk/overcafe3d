// 
// BewerageMaker.cs
//
// Used on interactable products like espresso machine, mocha pot and tea pot.
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
// ******------------------------------------------------------******
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PW
{
    [RequireComponent(typeof(Collider))]
    public class BewerageMaker : MonoBehaviour
    {
        #region AnimationSettings
        [SerializeField]
        public bool useAnimation = true;

        [SerializeField]
        public bool useTweeningAnimation = false;

        //Animation state for prefill.
        public string preFillAnimationStateName;

        //time takes to prefill.
        public float preFillProcess;

        //Animation ending state for fillEnded.
        public string fillEndedAnimationState;

        //time takes to fill the cup with particle.
        public float fillingProcess;

        [SerializeField]
        public Transform dummyAnimationTarget;
        //optional particle system to show drink getting filled.
        [SerializeField]
        public ParticleSystem fillParticle;

        //Used with tweening animation, to figure out the end position and rotation of the object.
        //You can duplicate the object, set it's transforms and delete the components like Mesh filter and renderer.
        [SerializeField]
        public Transform finalTweenTarget;

        #endregion

        //Drink prefab created from the product manager
        public GameObject cupType;
        

        //UI indicator to show progress
        public GameObject progressHelperprefab;
        public GameObject progressRefillprefab;
        public ParticleSystem breakParticle;

        //the position where the cup will be placed on instantiate
        public Transform fillCupSpot;

        public AudioClip AmericanoSound;
        public AudioClip MochapotSound;
        public AudioClip refillsound;
        public AudioClip waterrefillsound;
        public AudioClip breakSound;
        public AudioClip fixSound;

        [HideInInspector]
        public AudioSource DrinkSoundEffect;

        
        

        private bool isOnce;

        private bool mochaOnce;
        private bool teaOnce;

        private bool isAmericano;
        private bool isMochapot;
        private bool isRefilled;

        private bool isAmericanoloop;
        private bool isMochapotloop;
        private bool isRefillloop;
        bool isBreakloop;

        
        #region private variables
        private float totalProcess;

        private float currentRefill;

        private float totalRefill;

        private int breakNum;

        private bool isBreak;

        private Color defaultcolor;

        private int tutorialNum;

        bool canFillCup = true;

        FillCupHelper fillCupHelper;

        ProgressHelper m_progressHelper;

        ProgressHelper m_refillHelper;

        Collider m_Collider;

        Animator m_animator;
        #endregion

        void Start()
        {
            isOnce = true;
            mochaOnce = true;
            teaOnce = true;

            isBreakloop = true;
            isBreak = false;

            totalRefill = 5f;
            currentRefill = totalRefill;

            DrinkSoundEffect = GetComponent<AudioSource>();
            //find total time to process
            totalProcess = preFillProcess + fillingProcess;

            

            //Instantiate and set the UI indicator
            if (progressHelperprefab != null)
            {
                m_progressHelper = Instantiate(progressHelperprefab, transform).GetComponent<ProgressHelper>();

                defaultcolor = m_progressHelper.defaultColor();
                m_progressHelper.ToggleHelper(false);
            }

            if (progressRefillprefab != null)
            {
                m_refillHelper = Instantiate(progressRefillprefab, transform).GetComponent<ProgressHelper>();

                //m_refillHelper.UpdateProcessUI(currentRefill, totalRefill);
                m_refillHelper.ToggleHelper(true);
                m_refillHelper.UpdateProcessUI(currentRefill, totalRefill);

            }

            //get the collider and enable it 
            m_Collider = GetComponent<Collider>();

            m_Collider.enabled = true;

            //Get the animator from the dummy Target
            if (dummyAnimationTarget != null)
                m_animator = dummyAnimationTarget.GetComponent<Animator>();

            
            //if you want to use tweening we need to disable the animator.
            //It would override the transforms if we didn't
            if (useTweeningAnimation)
            {
                if(m_animator!=null)
                    m_animator.enabled = false;
            }

            if(cupType.name == "PW_espresso_cup_type2")
            {
                Debug.Log("AMERICANO!!!!!!!!!!!!!");
            }
                
        }

        private void Update()
        {
            if (GameManager.instance.isPaused)
            {

                DrinkSoundEffect.Pause();
            }

            if (!GameManager.instance.isPaused)
            {

                DrinkSoundEffect.UnPause();
            }

            StartCoroutine(CheckBeverage());
        }
        IEnumerator CheckBeverage()
        {
            yield return null;
            
            if (isAmericano)
            {

                if (isAmericanoloop)
                {
                    if (AmericanoSound != null)
                    {
                        DrinkSoundEffect.clip = AmericanoSound;
                        DrinkSoundEffect.Play();
                        DrinkSoundEffect.loop = true;
                        isAmericanoloop = false;
                    }
                }
            }
            if (!isAmericano)
            {
                if (!isAmericanoloop)
                {
                    DrinkSoundEffect.clip = null;
                    isAmericanoloop = true;
                }
                // Debug.Log("EMPTY");

            }


            if (isMochapot)
            {
                if (isMochapotloop)
                {
                    if (MochapotSound != null)
                    {
                        DrinkSoundEffect.clip = MochapotSound;
                        DrinkSoundEffect.Play();
                        DrinkSoundEffect.loop = true;
                        isMochapotloop = false;
                    }
                }
            }
            if (!isMochapot)
            {
                if (!isMochapotloop)
                {
                    DrinkSoundEffect.clip = null;
                    isMochapotloop = true;
                }
                // Debug.Log("EMPTY");

            }

            if (isRefilled)
            {
                if(isRefillloop)
                {
                    if (cupType.name == "PW_espresso_cup_type2" || cupType.name == "PW_espresso_cup_type_1stage")
                    {
                        DrinkSoundEffect.clip = refillsound;
                        DrinkSoundEffect.Play();
                        isRefillloop = false;
                    }

                    if (cupType.name == "MochaPotCup" || cupType.name == "TeaCupNew")
                    {
                        DrinkSoundEffect.clip = waterrefillsound;
                        DrinkSoundEffect.Play();
                        isRefillloop = false;
                    }
                }
            }

            if (!isRefilled)
            {
                if (!isRefillloop)
                {
                    DrinkSoundEffect.clip = null;
                    isRefillloop = true;
                }
            }

            if (isBreak)
            {
                if(isBreakloop)
                {
                    if(breakSound != null && breakParticle != null)
                    {
                        DrinkSoundEffect.clip = breakSound;
                        DrinkSoundEffect.loop = true;
                        //fillCupHelper.DestroyCup();
                        //UnSetTheCup();
                        DrinkSoundEffect.Play();
                        breakParticle.Play();
                        isBreakloop = false;
                    }
                }
            }

            if(!isBreak)
            {
                if(!isBreakloop)
                {
                    DrinkSoundEffect.clip = null;
                    breakParticle.Stop();
                    isBreakloop = true;
                }
            }


        }

        void OnMouseUp()
        {
            tutorialNum = PlayerPrefs.GetInt("productNum", 0);

            if (tutorialNum == 0)
            {
                if (GameManager.instance.isPaused)
                {
                    return;
                }
                Fungus.Flowchart.BroadcastFungusMessage("TouchCupcake!");
                return;
            }
            
            if (tutorialNum == 4)
            {
                if (GameManager.instance.isPaused)
                {
                    return;
                }
                Fungus.Flowchart.BroadcastFungusMessage("TouchToast!");
                return;
            }

            if (!GameManager.instance.isPaused)
            {
                if(isBreak)
                {
                    StartCoroutine(StartFix());
                }

                if (!isBreak)
                {
                    if (canFillCup)
                    {
                        //soundManager.instance.isCoffeeloop = true;
                        isOnce = true;
                        mochaOnce = true;
                        teaOnce = true;

                        StartFillingStep();
                       


                    }
                }
            }
        }

        IEnumerator StartFix()
        {
            
            m_Collider.enabled = false;
            float m_fix = 0f;
            float full_fix = 3f;
            var red = Color.red;
            print("START FIX");

            m_progressHelper.ToggleHelper(true);
            m_progressHelper.ChangeColor(red);

            if (fixSound != null)
            {
                DrinkSoundEffect.clip = fixSound;
                DrinkSoundEffect.loop = true;
                DrinkSoundEffect.Play();
            }

            while (m_fix < full_fix)
            {

                m_fix += Time.deltaTime;

                if (m_progressHelper != null)
                    m_progressHelper.UpdateProcessUI(m_fix, full_fix);

                yield return null;
            }

            m_Collider.enabled = true;

            if (fixSound != null)
            {
                DrinkSoundEffect.clip = null;
               
            }
            m_progressHelper.ToggleHelper(false);
            isBreak = false;
            m_progressHelper.ChangeColor(defaultcolor);
            //breakParticle.Stop();

        }

        void StartFillingStep()
        {
            // 바 양 줄이기 
            currentRefill--;
            m_refillHelper.UpdateProcessUI(currentRefill, totalRefill);

            if (currentRefill < 0)
            {
                currentRefill = 0;
                StartCoroutine(StartRefill());
                return;
            }
            canFillCup = false;

            //Instantiate and set the cup 
            SetTheCup();

            //Show the indicator
            if(m_progressHelper!=null)
                m_progressHelper.ToggleHelper(true);

            //Start playing the animations or tweening
            if (!string.IsNullOrEmpty(preFillAnimationStateName) || useTweeningAnimation)
            {
                StartPreFillAnimationState();
            }
            else
            {
                StartCoroutine(DoFillAnimation());

            }
        }

        void StartPreFillAnimationState()
        {
            if (!useTweeningAnimation)
            {
                if (m_animator != null)
                {
                    m_animator.SetTrigger(preFillAnimationStateName);
                }

            }
                StartCoroutine(DoPreFill(dummyAnimationTarget, finalTweenTarget));
        }

        IEnumerator DoPreFill(Transform target, Transform finalTweenValue)
        {
            //We do the tweening and update UI in this coroutine.

            float curPreFill = preFillProcess;
            Vector3 totalDist = Vector3.zero;
            Vector3 totalRot = Vector3.zero;
            Vector3 FinalPosition;
            Vector3 FinalRotation;

            if (finalTweenTarget != null && target != null)
            {
                FinalPosition = finalTweenValue.position;
                FinalRotation = finalTweenValue.rotation.eulerAngles;
                totalDist = (FinalPosition - target.transform.position);
                totalRot = (FinalRotation - target.transform.rotation.eulerAngles);
            }
            while (curPreFill > 0)
            {
                if (useTweeningAnimation)
                {
                    target.transform.position += (Time.deltaTime * totalDist) / preFillProcess;
                    target.transform.rotation = Quaternion.Euler(target.transform.rotation.eulerAngles + (Time.deltaTime * totalRot) / preFillProcess);
                }
                

                curPreFill -= Time.deltaTime;

                var now = preFillProcess - curPreFill;
                m_progressHelper.UpdateProcessUI(now, totalProcess);

                //print("dddd");
                if (cupType.name == "PW_espresso_cup_type2")
                {
                    if (isOnce)
                    {
                        print("Hi");
                        //soundManager.instance.isCoffeeloop = true;
                        isAmericano = true;
                        isOnce = false;
                    }
                }

                if (cupType.name == "PW_espresso_cup_type_1stage")
                {
                    if (isOnce)
                    {
                        print("Hi");
                        //soundManager.instance.isCoffeeloop = true;
                        isAmericano = true;
                        isOnce = false;
                    }
                }

                if (cupType.name == "MochaPotCup")
                {
                    if (mochaOnce)
                    {
                        print("MOcha");
                        //soundManager.instance.isMochaloop = true;
                        isMochapot = true;
                        mochaOnce = false;
                    }
                }

                if (cupType.name == "TeaCupNew")
                {
                    if (teaOnce)
                    {
                        print("Tea");
                        //soundManager.instance.isMochaloop = true;
                        isMochapot = true;
                        teaOnce = false;
                    }
                }
                yield return null;
            }

            //Starts Fill ended animation and the particle
            StartCoroutine(DoFillAnimation());
            
        }

        IEnumerator DoFillAnimation()
        {
            //If we don't have animation to play just fill the cup
            if (!useTweeningAnimation && (string.IsNullOrEmpty(fillEndedAnimationState) || fillingProcess < 0.001f))
            {
                fillCupHelper.DoFill(0f);
            }
            else
            {
                
                fillCupHelper.DoFill(fillingProcess);

                if (fillParticle != null)
                    fillParticle.Play();
                float fillCurrent = fillingProcess;

                while (fillCurrent > 0)
                {

                    fillCurrent -= Time.deltaTime;

                    

                    var valNow = preFillProcess + fillingProcess - fillCurrent;

                    if (m_progressHelper != null)
                        m_progressHelper.UpdateProcessUI(valNow, totalProcess);

                    yield return null;
                }

            }

            OnFillEnded();

        }



        void OnFillEnded()
        {
            //hide the UI indicator
            if(m_progressHelper!=null)
                m_progressHelper.ToggleHelper(false);

            //disable collider, because we don't want interaction on the object
            m_Collider.enabled = false;

            //tell the cup to enable its collider and set necessary things 
            fillCupHelper.FillEnded();

            if (fillParticle != null)
            {
                fillParticle.Stop();
            }
            Debug.Log("End!");
            //soundManager.instance.isCoffeeloop = false;
            //soundManager.instance.isMochaloop = false;
            isAmericano = false;
            isMochapot = false;
            StartCoroutine(DoFillEnded());

            
            if (breakParticle != null && breakSound != null)
            {
                breakNum = UnityEngine.Random.Range(0, 20);
                Debug.Log("RandomNum : " + breakNum);
                if (breakNum == 0 || breakNum == 19)
                {
                    print("Break!!");
                    isBreak = true;
                    isBreakloop = true;

                }
            }

            



        }

        
        void SetTheCup()
        {
            GameObject cup = Instantiate(cupType, fillCupSpot);

            fillCupHelper = cup.GetComponent<FillCupHelper>();

            /*if (cupType.name == "PW_espresso_cup_type2")
            {
                soundManager.instance.isCoffee = true;
            }*/

            fillCupHelper.SetMachine(this);

            if(m_progressHelper!=null)
                m_progressHelper.ToggleHelper(true);

        }

        public void UnSetTheCup()
        {
            canFillCup = true;

            fillCupHelper = null;

            m_Collider.enabled = true;
        }

        IEnumerator StartRefill()
        {
            m_Collider.enabled = false;

            GameManager.instance.scoreResult -= 3;

            float m_Refill = 0f;
            float full_Refill = 2f;
            isRefilled = true;

            while (m_Refill < full_Refill)
            {
                
                m_Refill += Time.deltaTime;
                
                if (m_refillHelper != null)
                    m_refillHelper.UpdateProcessUI(m_Refill, full_Refill);

                yield return null;
            }
            isRefilled = false;
            currentRefill = totalRefill;
            m_Collider.enabled = true;

        }

        /// <summary>
        /// Required things to do after fill ended such as reverse movement of a teapot,
        /// or playing an animation.
        /// </summary>
        /// <returns></returns>
        IEnumerator DoFillEnded()
        {
            if (m_animator != null && !string.IsNullOrEmpty(fillEndedAnimationState))
                m_animator.SetTrigger(fillEndedAnimationState);
            Vector3 totalDist = Vector3.zero;
            Vector3 totalRot = Vector3.zero;
            Vector3 FinalPosition;
            Vector3 FinalRotation;
            if (useTweeningAnimation)
            {
                //make the reverse movement as we did in the prefill

                float reverseMove = preFillProcess;
                if (dummyAnimationTarget != null && finalTweenTarget != null)
                {
                     FinalPosition = transform.position;
                     FinalRotation = transform.rotation.eulerAngles;
                     totalDist = (FinalPosition - dummyAnimationTarget.transform.position);
                     totalRot = (FinalRotation - dummyAnimationTarget.transform.rotation.eulerAngles);
                }

                while (reverseMove > 0)
                {
                    if (useTweeningAnimation)
                    {
                        dummyAnimationTarget.transform.position += (Time.deltaTime * totalDist) / preFillProcess;
                        dummyAnimationTarget.transform.rotation = Quaternion.Euler(dummyAnimationTarget.transform.rotation.eulerAngles + (Time.deltaTime * totalRot) / preFillProcess);
                        

                    }
                    reverseMove -= Time.deltaTime;
                    yield return null;
                }
                if (dummyAnimationTarget != null)
                {
                    dummyAnimationTarget.localPosition = Vector3.zero;
                    dummyAnimationTarget.transform.localRotation = Quaternion.identity;
                }
                
            }

            yield return null;
        }

    }
}