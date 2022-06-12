// 
// ReadyToServe.cs
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PW
{
    public class ReadyToServe : ProductGameObject
    {
        

        public GameObject platePrefab;


        Collider m_collider;

        private int tutorialNum;

        private void Awake()
        {
            
            m_collider = GetComponent<Collider>();
            m_collider.enabled = true;
        }

        void OnMouseDown()
        {
            tutorialNum = PlayerPrefs.GetInt("productNum", 0);
            
            /*if (tutorialNum == 2)
            {
                if (GameManager.instance.isPaused)
                {
                    return;
                }
                Fungus.Flowchart.BroadcastFungusMessage("TouchEspressoMachine!");
                return;
            }*/

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
                if (!base.CanGoPlayerSlot())
                {
                    return;
                }



                if (AddToPlateBeforeServed)
                {
                    var plate = GameObject.Instantiate(platePrefab, transform.position, Quaternion.identity);
                    plate.transform.SetParent(transform);
                    if (plateOffset.magnitude > 0)
                    {
                        plate.transform.localPosition = plateOffset;
                    }
                    plate.transform.SetAsFirstSibling();//so we know what to delete later



                }
                if (RegenerateProduct)
                {
                    BasicGameEvents.RaiseInstantiatePlaceHolder(transform.parent, transform.position, gameObject);
                }

                StartCoroutine(AnimateGoingToSlot());

                soundManager.instance.isServed = true;
            }
            

        }

        public override IEnumerator AnimateGoingToSlot()
        {
            if (RegenerateProduct)
            {
                if (AddToPlateBeforeServed)
                {
                    Destroy(transform.GetChild(0).gameObject);
                }
            }
            yield return base.AnimateGoingToSlot();

            gameObject.SetActive(false);
        }

    }
}