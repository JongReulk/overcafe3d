// ******------------------------------------------------------******
// StoveGameObject.cs
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
// ******------------------------------------------------------******
using UnityEngine;
using System.Collections;
namespace PW
{

    public class StoveGameObject : CookingGameObject
    {
        public Transform doorTransform;

        //private Vector3 progressHelperOffset = new Vector3(0f, 0f, 0f);

        public bool doorIsOpen = false;
        private bool isAnimating;

        private AudioSource StoveAudio;

        public AudioClip StoveSound;
        public AudioClip overCookedSound;
        public AudioClip smokeSound;
        public AudioClip washSound;
        //public AudioClip breakSound;
        //public AudioClip fixSound;

        //public ParticleSystem breakParticle;

        private bool isStoveloop;
        private bool isOvercookloop;
        private bool isSmokeloop;
        private bool isWashloop;

         //private bool isBreak;
        bool isBreakloop;
        
        private void Start()
        {
            StoveAudio = GetComponent<AudioSource>();

            //StartCoroutine(CheckPan());

            //Instantiate and set the UI indicator
            if (progressHelperprefab != null)
            {
                print("Instantiate progress Helper Prefeb");
                m_progressHelper = Instantiate(progressHelperprefab, transform).GetComponent<ProgressHelper>();
                defaultcolor = m_progressHelper.defaultColor();
                //dont show the indicator now
                m_progressHelper.ToggleHelper(false);
            }

            if (m_progressHelper != null)
            {
                print("m_progressHelper not null");
            }

            if (overCookedMark != null)
            {

                m_overCookedMark = Instantiate(overCookedMark, transform).GetComponent<Overcooked>();
                //dont show the indicator now
                m_overCookedMark.overcookedHelper(false);
            }

        }

        private void Update()
        {
            if (GameManager.instance.isPaused)
            {
                
                StoveAudio.Pause();
            }

            if (!GameManager.instance.isPaused)
            {
                
                StoveAudio.UnPause();
            }

            StartCoroutine(CheckPan());

        }


        IEnumerator CheckPan()
        {
            yield return null;

            if (!IsEmpty())
            {

                if (isStoveloop)
                {
                    StoveAudio.clip = StoveSound;
                    StoveAudio.Play();
                    StoveAudio.loop = true;
                    isStoveloop = false;
                }
            }
            if (IsEmpty())
            {
                if (!isStoveloop)
                {
                    StoveAudio.clip = null;
                    isStoveloop = true;
                }
                // Debug.Log("EMPTY");

            }

            if (IsOverCook())
            {

                if (isOvercookloop)
                {
                    StoveAudio.clip = overCookedSound;
                    StoveAudio.Play();
                    StoveAudio.loop = false;
                    isOvercookloop = false;
                }
            }

            if (!IsOverCook())
            {
                if (!isOvercookloop)
                {
                    StoveAudio.clip = null;
                    isOvercookloop = true;
                }
            }


            if (IsSmoke())
            {
                if (isSmokeloop)
                {
                    StoveAudio.clip = smokeSound;
                    StoveAudio.Play();
                    StoveAudio.loop = true;
                    isSmokeloop = false;
                }
            }

            if (!IsSmoke())
            {
                if (!isSmokeloop)
                {
                    StoveAudio.clip = null;
                    isSmokeloop = true;
                }
            }

            if (IsWash())
            {
                if (isWashloop)
                {
                    StoveAudio.clip = washSound;
                    StoveAudio.Play();
                    StoveAudio.loop = true;
                    isWashloop = false;
                }
            }

            if (!IsWash())
            {
                if (!isWashloop)
                {
                    StoveAudio.clip = null;
                    isWashloop = true;
                }
            }

            if (isBreak)
            {
                if (isBreakloop)
                {
                    if (breakSound != null && breakParticle != null)
                    {
                        StoveAudio.clip = breakSound;
                        StoveAudio.loop = true;

                        StoveAudio.Play();
                        breakParticle.Play();
                        isBreakloop = false;
                    }
                }
            }

            if (!isBreak)
            {
                if (!isBreakloop)
                {
                    StoveAudio.clip = null;
                    breakParticle.Stop();
                    isBreakloop = true;
                }
            }

        }

        public override void DoDoorAnimationsIfNeeded()
        {
            base.DoDoorAnimationsIfNeeded();
            if(!isAnimating)
                StartCoroutine(PlayDoorAnim(true, true));
        }

        public override void StartCooking(CookableProduct product)
        {
            
            base.StartCooking(product);
            //m_progressHelper.transform.position += progressHelperOffset;
        }


        IEnumerator PlayDoorAnim(bool open, bool alsoReverse = false)
        {
            //doorIsOpen = open;
            //isAnimating = true;
            float totalTime = doorAnimTime;
            float curTime = totalTime;
            float totalAngle = 66;
            float multiplier = 1f;
            float finalAngle = 66;
            
            if (!open)
            {
                finalAngle = 0;
                multiplier = -1f;
            }

            if(open)
            {
                doorIsOpen = true;
                isAnimating = true;
            }

            

            while (curTime > 0)
            {
                var amount = Time.deltaTime;
                var eulerTemp = doorTransform.rotation.eulerAngles;

                doorTransform.Rotate(new Vector3( (multiplier * totalAngle) * amount / totalTime,0f, 0f),Space.Self);
                curTime -= Time.deltaTime;
                yield return null;
            }
            doorTransform.localRotation= Quaternion.Euler(new Vector3(finalAngle,0f, 0f));
            //doorIsOpen = false;

            yield return new WaitForSeconds(.2f);
            if (alsoReverse)
            {
                yield return StartCoroutine(PlayDoorAnim(!open, false));
                isAnimating = false;

            }
            
            //else
            //isAnimating = false;

            if(!open)
            {
                doorIsOpen = false;
                isAnimating = false;
            }

            
        }


        public override void OnMouseDown()
        {
            
            if (!doorIsOpen && !IsEmpty())
            {
                if (isBreak)
                {
                    StartCoroutine(StartFix());
                }
                else
                {
                    
                    base.OnMouseDown();
                }
            }
            else
            {
                
                return;
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
                StoveAudio.clip = fixSound;
                StoveAudio.loop = true;
                StoveAudio.Play();
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
                StoveAudio.clip = null;

            }
            m_progressHelper.ToggleHelper(false);
            isBreak = false;
            m_progressHelper.ChangeColor(defaultcolor);


            //breakParticle.Stop();

        }

    }
}
