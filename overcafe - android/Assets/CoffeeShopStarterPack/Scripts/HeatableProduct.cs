// ******------------------------------------------------------******
// HeatableProduct.cs
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
//
// ******------------------------------------------------------******

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PW
{
    public class HeatableProduct : ProductGameObject
    {

        Collider m_collider;

        private Vector3 initialPosition;

        public Microwave m_Machine;

        public GameObject platePrefab;

        private GameObject m_plate;

        public float heatingTimeForProduct;

        private int tutorialNum;

        private void Awake()
        {
            m_collider = GetComponent<Collider>();
            m_collider.enabled = true;

        }

        private void OnEnable()
        {
            initialPosition = transform.position;
        }

        private void Start()
        {
            //If you didn't set a microwave yourself,
            //We'll try to get one from the scene when available
            if (m_Machine == null)
                m_Machine = FindObjectOfType<Microwave>();
        }

        public override bool CanGoPlayerSlot()
        {
            if (base.CanGoPlayerSlot())
            {

                StartCoroutine(AnimateGoingToSlot());
                return true;
            }
            return false;
        }

        void OnMouseDown()
        {
            tutorialNum = PlayerPrefs.GetInt("productNum", 0);

            if (tutorialNum == 0)
            {
                if(GameManager.instance.isPaused)
                {
                    return;
                }
                Fungus.Flowchart.BroadcastFungusMessage("TouchCupcake!");
                return;
            }

            /*if (tutorialNum == 2)
            {
                if (GameManager.instance.isPaused)
                {
                    return;
                }

                Fungus.Flowchart.BroadcastFungusMessage("TouchEspressoMachine!");
                return;
            }*/

            

            if (GameManager.instance.isPaused)
                return;

            if (m_Machine != null)
            {
                //Check if machine is available before doing anything
                if (m_Machine.isEmpty )
                {
                    if (AddToPlateBeforeServed)
                    {
                        var plate = Instantiate(platePrefab, transform.position, Quaternion.identity);
                        plate.transform.SetParent(transform);
                        m_plate = plate;
                        //plate.transform.SetAsFirstSibling();
                    }
                    
                    m_Machine.SetProduct(this, heatingTimeForProduct);
                    
                    StartCoroutine(MoveToMicrowave());
                    
                }
            }
        }

        IEnumerator MoveToMicrowave()
        {
            //Set the product at starting position
            transform.position = m_Machine.beginEnteringSpot.position;

            yield return base.MoveToPlace(m_Machine.cookingSpot.position);
        }

        public override IEnumerator AnimateGoingToSlot()
        {
            if (RegenerateProduct)
            {
                //Remove the plate first
                if (AddToPlateBeforeServed)
                {

                    Destroy(transform.GetChild(transform.childCount-1).gameObject);
                    //Destroy(m_plate);
                }
                else if (serveAsDifferentGameObject != null)
                {
                    //Remove the served as Different gameobject first
                    
                    Destroy(transform.GetChild(0).gameObject);
                }
                BasicGameEvents.RaiseInstantiatePlaceHolder(transform.parent, initialPosition, gameObject);

            }
            yield return base.AnimateGoingToSlot();

            gameObject.SetActive(false);
        }

        public void FoodDestroy()
        {
            if (RegenerateProduct)
            {
                BasicGameEvents.RaiseInstantiatePlaceHolder(transform.parent, initialPosition, gameObject);
            }
            gameObject.SetActive(false);
        }
    }
}