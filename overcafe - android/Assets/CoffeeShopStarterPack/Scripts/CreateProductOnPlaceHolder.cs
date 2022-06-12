// ******------------------------------------------------------******
// CreateProductOnPlaceHolder.cs
// Generates the new product on position of the placeholder 
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
// ******------------------------------------------------------******
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PW
{

    public class CreateProductOnPlaceHolder : MonoBehaviour
    {
        //This is set when the placeholder is created,
        //so we know what to generate
        public GameObject objectToGenerate;


        private void OnMouseDown()
        {
            if (!GameManager.instance.isPaused)
            {
                soundManager.instance.isRefill = true;

                print("REFILL BUTTON");

                GameManager.instance.scoreResult -= 5;

                var go = GameObject.Instantiate(objectToGenerate);
                //var go = GameObject.Instantiate(objectToGenerate, transform.parent);
                Destroy(objectToGenerate);
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;

                var m_collider = go.GetComponent<Collider>();
                m_collider.enabled = true;

                go.SetActive(true);

                //Remove the plate first if we have one.
                var productGO = go.GetComponent<ProductGameObject>();
                //if (productGO.AddToPlateBeforeServed)
                //{
                    //Destroy(go.transform.GetChild(0).gameObject);
                //}


                Destroy(gameObject);
            }
        }
    }
}
