// ******------------------------------------------------------******
// PanGameObject.cs
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
    /// <summary>
    /// This class is just an example of how you can inherit from cookingGameObject.
    /// This class doesn't have overrides of base methods, and it doesn't have methods itself.
    /// The pan object on the gameplay scene uses this script and
    /// it just works by inheriting from the base class.
    /// </summary>
    
    public class PanGameObject : CookingGameObject
    {
        private AudioSource PanAudio;

        public AudioClip PanSound;
        public AudioClip overCookedSound;
        public AudioClip smokeSound;
        public AudioClip washSound;

        private bool isPanloop;
        private bool isOvercookloop;
        private bool isSmokeloop;
        private bool isWashloop;


        
        private void Start()
        {
            PanAudio = GetComponent<AudioSource>();

            //StartCoroutine(CheckPan());

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

        private void Update()
        {
            if (GameManager.instance.isPaused)
            {
                
                PanAudio.Pause();
            }

            if (!GameManager.instance.isPaused)
            {
                
                PanAudio.UnPause();
            }

            StartCoroutine(CheckPan());
            
        }

        
        IEnumerator CheckPan()
        {
            yield return null;
            
            if (!IsEmpty())
            {
                
                if (isPanloop)
                {
                    PanAudio.clip = PanSound;
                    PanAudio.Play();
                    PanAudio.loop = true;
                    isPanloop = false;
                }
            }
            if (IsEmpty())
            {
                if (!isPanloop)
                {
                    PanAudio.clip = null;
                    isPanloop = true;
                }
                // Debug.Log("EMPTY");

            }

            if (IsOverCook())
            {
                
                if (isOvercookloop)
                {
                    PanAudio.clip = overCookedSound;
                    PanAudio.Play();
                    PanAudio.loop = false;
                    isOvercookloop = false;
                }
            }

            if (!IsOverCook())
            {
                if (!isOvercookloop)
                {
                    PanAudio.clip = null;
                    isOvercookloop = true;
                }
            }

            
            if (IsSmoke())
            {
                if (isSmokeloop)
                {
                    PanAudio.clip = smokeSound;
                    PanAudio.Play();
                    PanAudio.loop = true;
                    isSmokeloop = false;
                }
            }

            if (!IsSmoke())
            {
                if (!isSmokeloop)
                {
                    PanAudio.clip = null;
                    isSmokeloop = true;
                }
            }

            if (IsWash())
            {
                if (isWashloop)
                {
                    PanAudio.clip = washSound;
                    PanAudio.Play();
                    PanAudio.loop = true;
                    isWashloop = false;
                }
            }

            if (!IsWash())
            {
                if (!isWashloop)
                {
                    PanAudio.clip = null;
                    isWashloop = true;
                }
            }






        }



    }
}
