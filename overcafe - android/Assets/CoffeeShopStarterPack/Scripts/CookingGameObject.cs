// ******------------------------------------------------------******
// CookingGameObject.cs
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
    public class CookingGameObject : MonoBehaviour
    {

        //offset to Pivot, Vector3.zero is the default.
        public Vector3 cookingSpot;

        //Animation starting position can be set here,zero is default.
        public Vector3 startingPositionOffset;

        public CookableProduct currentProduct;

        public GameObject progressHelperprefab;

        public GameObject overCookedMark;

        public ParticleSystem overcooked_Particle;

        public ParticleSystem washing_Particle;


        [HideInInspector]
        public ProgressHelper m_progressHelper;
        [HideInInspector]
        public Overcooked m_overCookedMark;

        private bool stillovercooked;
        [HideInInspector]
        public bool destroyfood;
        //public ProgressHelper m_progressHelper;

        public float doorAnimTime = 1f;
        [HideInInspector]
        public bool isOverCooked;
        [HideInInspector]
        public bool isDestroyed;
        [HideInInspector]
        public bool isSmoked;
        [HideInInspector]
        public bool isWashed;

        public AudioClip breakSound;
        public AudioClip fixSound;
        public ParticleSystem breakParticle;

        public float cookingProcess;

        public Collider m_Collider;

        public int breakNum;

        public bool isBreak;

        public Color defaultcolor;

        private void Awake()
        {
            m_Collider = GetComponent<Collider>();
            destroyfood = false;
            stillovercooked = false;
        }

        private void Start()
        {
            
            //Instantiate and set the UI indicator
            if (progressHelperprefab != null)
            {
                print("Instantiate progress Helper Prefeb");
                m_progressHelper = Instantiate(progressHelperprefab, transform).GetComponent<ProgressHelper>();
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
        /// <summary>
        /// We use this method to make this available through a system,
        /// if you had more than one cooking object and a manager had selected one of the pans,
        /// you would get this script from the array and just call this method
        /// to get the exact position of the available cooking object.
        /// </summary>
        /// <returns>Cooking position of the object in WorldPos with offset</returns>
        public virtual Vector3 GetCookingPosition()
        {
            return transform.position + cookingSpot;
        }

        public virtual void DoDoorAnimationsIfNeeded()
        {
           
        }

        public virtual bool IsEmpty()
        {
            return currentProduct == null;
        }

        public virtual bool IsOverCook()
        {
            if (isOverCooked == true)
            {
                return true;
            }

            else
                return false;
            
        }

        public virtual bool IsSmoke()
        {
            return isSmoked;
        }

        public virtual bool IsWash()
        {
            return isWashed;
        }


        public virtual void StartCooking(CookableProduct product)
        {
            currentProduct = product;
            cookingProcess = product.cookingTimeForProduct;
            print("StartCooking");

            m_Collider.enabled = false;
            StartCoroutine(Cooking());
        }

        public virtual void ReadyToServe()
        {
            currentProduct = null;
            m_Collider.enabled = true;
            DoDoorAnimationsIfNeeded();
        }

        public virtual bool HasStartAnimationPos(out Vector3 result)
        {
            result = Vector3.zero;
            if (startingPositionOffset != Vector3.zero)
            {
                result = transform.position + startingPositionOffset;
                return true;
            }
            else
                return false;
        }

        public virtual IEnumerator Cooking()
        {
            print("Cooking");
            m_progressHelper.ToggleHelper(true);
            
            var curTime = cookingProcess+doorAnimTime;
            while (curTime > 0)
            {
                curTime -= Time.deltaTime;
                m_progressHelper.UpdateProcessUI(curTime, cookingProcess);
                yield return null;
            }
            currentProduct.DoneCooking();
            m_progressHelper.ToggleHelper(false);
            m_Collider.enabled = true;

            if (breakParticle == null && breakSound == null)
            {
                Invoke("SetOvercooked", 4f);
            }

            if (breakParticle != null && breakSound != null)
            {
                breakNum = UnityEngine.Random.Range(0, 5);

                Debug.Log("RandomNum : " + breakNum);
                if (breakNum == 0 || breakNum == 4)
                {
                    print("Break!!");
                    isBreak = true;
                }
                if (!isBreak)
                {
                    Invoke("SetOvercooked", 4f);
                }
            }
            
        }

        public virtual void OnMouseDown()
        {
            Debug.Log("still over? " + stillovercooked);

            Debug.Log("CookingObject Click!");

            if(currentProduct!=null && currentProduct.IsCooked)
            {
                if (destroyfood)
                {
                    m_overCookedMark.overcookedHelper(false);
                    //soundManager.instance.isOverCooked = false;
                    isOverCooked = false;
                    currentProduct.FoodDestroy();
                    soundManager.instance.isDeleted = true;
                    destroyfood = false;
                    StartCoroutine(RemoveSmoke());
                }
                //Try to serve currentProduct if player slots are available
                if (!destroyfood)
                {
                    if (currentProduct.CanGoPlayerSlot())
                    {

                        ReadyToServe();
                        soundManager.instance.isServed = true;
                        m_overCookedMark.overcookedHelper(false);
                        //soundManager.instance.isOverCooked = false;
                        isOverCooked = false;
                        stillovercooked = false;

                    }
                    else
                        return;
                }
                    /*m_progressHelper.ToggleHelper(true);
                    var cleanTime = 2f;
                    m_Collider.enabled = false;
                    while (cleanTime > 0)
                    {
                        print("BLAAAA");
                        cleanTime -= Time.deltaTime;
                        m_progressHelper.UpdateProcessUI(cleanTime, 2f);
                    }
                    m_progressHelper.ToggleHelper(false);
                    m_Collider.enabled = true;
                    overcooked_Particle.Stop();
                    stillovercooked = false;*/
                
            }
            else
            {
                    //DoDoorAnimationsIfNeeded();
            }

        }

        void SetOvercooked()
        {
            if (currentProduct != null && currentProduct.IsCooked)
            {
                stillovercooked = true;
                //soundManager.instance.isOverCooked = true;
                isOverCooked = true;
                StartCoroutine(setOvercookedMark());
                //m_overCookedMark.overcookedHelper(true);
                Invoke("checkOvercooked", 6f);
            }
        }

        void checkOvercooked()
        {
            if(GameManager.instance.isGameOver)
            {
                return;
            }
            if(stillovercooked)
            {
                print("OverCooked!!");
                m_overCookedMark.overcookedHelper(false);
                soundManager.instance.isDestroyed = true;
                
                //soundManager.instance.isSmoke = true;
                isSmoked = true;
                if (overcooked_Particle != null)
                    overcooked_Particle.Play();
                destroyfood = true;
            }
            if(!stillovercooked)
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
            m_Collider.enabled = false;
            //soundManager.instance.isWash = true;
            isWashed = true;
            //soundManager.instance.isSmoke = false;

            if (washing_Particle != null)
                washing_Particle.Play();
            while (cleanTime > 0)
            {
                
                cleanTime -= Time.deltaTime;
                m_progressHelper.UpdateProcessUI(cleanTime, 3f);
                yield return null;
            }
            m_progressHelper.ToggleHelper(false);
            m_Collider.enabled = true;
            //soundManager.instance.isWash = false;
            isWashed = false;
            washing_Particle.Stop();
            overcooked_Particle.Stop();
            stillovercooked = false;
            currentProduct = null;
            
        }

        IEnumerator setOvercookedMark()
        {
            if (GameManager.instance.isGameOver)
            {
                yield break;
            }
            int count = 5;
            while(count > 0)
            {
                if(currentProduct == null)
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