// ******------------------------------------------------------******
// Microwave.cs
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

    public class Microwave : MonoBehaviour
    {
        HeatableProduct currentProduct; // The product we currently heating inside
        bool doorIsOpen;

        Collider m_collider;

        public Transform door;
        public Transform beginEnteringSpot;
        public Transform cookingSpot;

        public GameObject progressHelperprefab;

        public GameObject overCookedMark;

        public ParticleSystem overcooked_Particle;

        public ParticleSystem washing_Particle;

        public ParticleSystem breakParticle;

        private AudioSource MicrowaveAudio;

        public AudioClip MicrowaveSound;
        public AudioClip overCookedSound;
        public AudioClip smokeSound;
        public AudioClip washSound;
        public AudioClip breakSound;
        public AudioClip fixSound;



        private bool doorloop;

        private bool isMicrowave;
        private bool isOverCook;
        private bool isSmoke;
        private bool isWash;
        private bool isMicro;

        private bool isMicrowaveloop;
        private bool isOvercookloop;
        private bool isSmokeloop;
        private bool isWashloop;

        private int breakNum;

        private bool isBreak;
        bool isBreakloop;

        private Color defaultcolor;


        ProgressHelper m_progressHelper;
        Overcooked m_overCookedMark;

        float heatingProcess;//how much time 

        private bool stillovercooked;
        public bool destroyfood;

        public bool isEmpty
        {
            get
            {
                return !doorIsOpen && currentProduct == null;
            }
        }
        private void Start()
        {
            //Instantiate and set the UI indicator
            MicrowaveAudio = GetComponent<AudioSource>();
            m_collider = GetComponent<Collider>();
            if (progressHelperprefab != null)
            {
                m_progressHelper = Instantiate(progressHelperprefab, transform).GetComponent<ProgressHelper>();
                //dont show the indicator now
                defaultcolor = m_progressHelper.defaultColor();
                m_progressHelper.ToggleHelper(false);
            }

            destroyfood = false;
            stillovercooked = false;
            doorloop = true;

            if (overCookedMark != null)
            {

                m_overCookedMark = Instantiate(overCookedMark, transform).GetComponent<Overcooked>();
                //dont show the indicator now
                m_overCookedMark.overcookedHelper(false);
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.instance.isPaused)
            {

                MicrowaveAudio.Pause();
            }

            if (!GameManager.instance.isPaused)
            {

                MicrowaveAudio.UnPause();
            }

            StartCoroutine(CheckMicrowave());
        }

        IEnumerator CheckMicrowave()
        {
            yield return null;

            if (isMicrowave)
            {

                if (isMicrowaveloop)
                {
                    MicrowaveAudio.clip = MicrowaveSound;
                    MicrowaveAudio.Play();
                    MicrowaveAudio.loop = true;
                    isMicrowaveloop = false;
                }
            }
            if (!isMicrowave)
            {
                if (!isMicrowaveloop)
                {
                    MicrowaveAudio.clip = null;
                    isMicrowaveloop = true;
                }
                // Debug.Log("EMPTY");

            }

            if (isOverCook)
            {

                if (isOvercookloop)
                {
                    MicrowaveAudio.clip = overCookedSound;
                    MicrowaveAudio.Play();
                    MicrowaveAudio.loop = false;
                    isOvercookloop = false;
                }
            }

            if (!isOverCook)
            {
                if (!isOvercookloop)
                {
                    MicrowaveAudio.clip = null;
                    isOvercookloop = true;
                }
            }


            if (isSmoke)
            {
                if (isSmokeloop)
                {
                    MicrowaveAudio.clip = smokeSound;
                    MicrowaveAudio.Play();
                    MicrowaveAudio.loop = true;
                    isSmokeloop = false;
                }
            }

            if (!isSmoke)
            {
                if (!isSmokeloop)
                {
                    MicrowaveAudio.clip = null;
                    isSmokeloop = true;
                }
            }

            if (isWash)
            {
                if (isWashloop)
                {
                    MicrowaveAudio.clip = washSound;
                    MicrowaveAudio.Play();
                    MicrowaveAudio.loop = true;
                    isWashloop = false;
                }
            }

            if (!isWash)
            {
                if (!isWashloop)
                {
                    MicrowaveAudio.clip = null;
                    isWashloop = true;
                }
            }

            if (isBreak)
            {
                if (isBreakloop)
                {
                    if (breakSound != null && breakParticle != null)
                    {
                        MicrowaveAudio.clip = breakSound;
                        MicrowaveAudio.loop = true;

                        MicrowaveAudio.Play();
                        breakParticle.Play();
                        isBreakloop = false;
                    }
                }
            }

            if (!isBreak)
            {
                if (!isBreakloop)
                {
                    MicrowaveAudio.clip = null;
                    breakParticle.Stop();
                    isBreakloop = true;
                }
            }

        }

        public void SetProduct(HeatableProduct product,float heatingAmount)
        {
            if (doorIsOpen || currentProduct != null)
                return;
            currentProduct = product;
            heatingProcess = heatingAmount;
            //isMicro = true;
            isMicrowave = false;
            StartCoroutine(OpenMicrowaveAndHeatProduct());
            
        }

        IEnumerator OpenMicrowaveAndHeatProduct()
        {
            m_collider.enabled = false;
            yield return StartCoroutine(PlayDoorAnim(true, true));
            yield return StartCoroutine(Heating());
        }


        IEnumerator PlayDoorAnim(bool open, bool alsoReverse = false)
        {
            
            float totalTime = 1f;
            float curTime = totalTime;
            float totalAngle = 90;
            float multiplier = 1f;
            float finalAngle = 90;
            if (!open)
            {
                finalAngle = 0;
                multiplier = -1f;
            }

            if(open)
            {
                doorIsOpen = true;
            }
            
            while (curTime > 0)
            {
                var amount = Time.deltaTime;

                door.transform.Rotate(new Vector3(0f, (multiplier * totalAngle) * amount / totalTime, 0f),Space.Self);
                curTime -= Time.deltaTime;
                yield return null;
            }
            door.transform.localRotation= Quaternion.Euler(new Vector3(0f, finalAngle, 0f));
            //doorIsOpen = false;

            yield return new WaitForSeconds(.2f);

            

            if (alsoReverse)
            {

                yield return StartCoroutine(PlayDoorAnim(!open, false));
            }

            if (!open)
            {
                doorIsOpen = false;
                
            }




        }

        IEnumerator Heating()
        {
            m_progressHelper.ToggleHelper(true);
            isMicrowave = true;

            float curProcess = heatingProcess;
            
            while (curProcess > 0)
            {
                
                curProcess -= Time.deltaTime;
                m_progressHelper.UpdateProcessUI(curProcess, heatingProcess);
                yield return null;
            }
            m_progressHelper.ToggleHelper(false);
            m_collider.enabled = true;

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
            if (!isBreak)
            {
                Invoke("SetOvercooked", 4f);
            }

        }

        IEnumerator StartFix()
        {

            m_collider.enabled = false;
            float m_fix = 0f;
            float full_fix = 3f;
            var red = Color.red;
            print("START FIX");

            m_progressHelper.ToggleHelper(true);
            m_progressHelper.ChangeColor(red);

            if (fixSound != null)
            {
                MicrowaveAudio.clip = fixSound;
                MicrowaveAudio.loop = true;
                MicrowaveAudio.Play();
            }

            while (m_fix < full_fix)
            {

                m_fix += Time.deltaTime;

                if (m_progressHelper != null)
                    m_progressHelper.UpdateProcessUI(m_fix, full_fix);

                yield return null;
            }

            m_collider.enabled = true;

            if (fixSound != null)
            {
                MicrowaveAudio.clip = null;

            }
            m_progressHelper.ToggleHelper(false);
            isBreak = false;
            m_progressHelper.ChangeColor(defaultcolor);
            
            
            //breakParticle.Stop();

        }

        private void OnMouseDown()
        {
            Debug.Log("Destroy food"+ destroyfood);
            //print(doorIsOpen);
            if (!doorIsOpen && !isEmpty)
            {
                

                if (!destroyfood)
                {
                    if (isBreak)
                    {
                        StartCoroutine(StartFix());
                    }

                    var PlayerSlots = FindObjectOfType<PlayerSlots>();
                    if (!isBreak)
                    {
                        if (currentProduct.CanGoPlayerSlot())
                        //if (PlayerSlots.CanHoldItem(currentProduct.orderID))
                        {

                            //BasicGameEvents.RaiseOnProductAddedToSlot(currentProduct.orderID);
                            //StartCoroutine(currentProduct.AnimateGoingToSlot());
                            isMicrowave = false;
                            currentProduct = null;
                            StartCoroutine(PlayDoorAnim(true, true));
                            soundManager.instance.isServed = true;
                            m_overCookedMark.overcookedHelper(false);
                            //soundManager.instance.isOverCooked = false;
                            isOverCook = false;
                            stillovercooked = false;
                        }
                        else
                            return;
                    }
                }

                



                if (destroyfood)
                {
                    m_overCookedMark.overcookedHelper(false);
                    //soundManager.instance.isOverCooked = false;
                    isOverCook = false;
                    currentProduct.FoodDestroy();
                    soundManager.instance.isDeleted = true;
                    destroyfood = false;
                    StartCoroutine(RemoveSmoke());
                }
                
            }
            /*else if(isEmpty)
            {
                StartCoroutine(PlayDoorAnim(true, true));

            }*/

        }

        void SetOvercooked()
        {
            if (GameManager.instance.isGameOver)
            {
                return;
            }

            if (GameManager.instance.isPaused)
            {
                return;
            }
            if (!doorIsOpen && !isEmpty)
            {
                stillovercooked = true;
                //soundManager.instance.isOverCooked = true;
                isOverCook = true;
                StartCoroutine(setOvercookedMark());
                //m_overCookedMark.overcookedHelper(true);
                Invoke("checkOvercooked", 6f);
            }
            else
                return;
        }

        void checkOvercooked()
        {
            if (GameManager.instance.isGameOver)
            {
                return;
            }

            if (GameManager.instance.isPaused)
            {
                return;
            }
            if (stillovercooked)
            {
                print("OverCooked!!");
                m_overCookedMark.overcookedHelper(false);
                soundManager.instance.isDestroyed = true;

                //soundManager.instance.isSmoke = true;
                isSmoke = true;
                if (overcooked_Particle != null)
                    overcooked_Particle.Play();
                destroyfood = true;
            }
            if (!stillovercooked)
            {
                print("good");
                m_overCookedMark.overcookedHelper(false);
                destroyfood = false;
            }

            //m_overCookedMark.overcookedHelper(true);


        }

        IEnumerator RemoveSmoke()
        {
            m_progressHelper.ToggleHelper(true);
            var cleanTime = 3f;
            m_collider.enabled = false;
            //soundManager.instance.isWash = true;
            isWash = true;
            //soundManager.instance.isSmoke = false;
            isSmoke = false;

            if (washing_Particle != null)
                washing_Particle.Play();
            while (cleanTime > 0)
            {

                cleanTime -= Time.deltaTime;
                m_progressHelper.UpdateProcessUI(cleanTime, 3f);
                yield return null;
            }
            m_progressHelper.ToggleHelper(false);
            //soundManager.instance.isWash = false;
            isWash = false;
            washing_Particle.Stop();
            overcooked_Particle.Stop();
            stillovercooked = false;
            m_collider.enabled = true;
            currentProduct = null;
            

        }

        IEnumerator setOvercookedMark()
        {
            if (GameManager.instance.isGameOver)
            {
                yield break;
            }
            int count = 5;
            while (count > 0)
            {
                if (currentProduct == null)
                    yield break;
                m_overCookedMark.overcookedHelper(true);
                yield return new WaitForSeconds(0.5f);
                m_overCookedMark.overcookedHelper(false);
                yield return new WaitForSeconds(0.5f);
                count--;
            }
        }
    }
}
