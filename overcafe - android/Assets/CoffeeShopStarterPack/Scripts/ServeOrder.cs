// ******------------------------------------------------------******
// ServeOrder.cs
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
// ******------------------------------------------------------******
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PW
{
    public class ServeOrder : MonoBehaviour
    {

        int order_count = 1;
        //for demo we only check for one product
        //by order but you can add more products for a serving.
        int total_order_served = 0;

        float totalServingTime;//Total serving time for order

        float curServeTime; //How much time left

        Image m_Image;//Image to hold product sprite.

        public int orderID; //what is MyProduct ID

        public float productPrice;

        public Image serveTimeRepresentation;

        private bool isComplete;

        private bool isSpecialOrder;

        private bool isOrdering;


        public void ServeMe()
        {
            var PlayerSlots = FindObjectOfType<PlayerSlots>();

            if (PlayerSlots != null)
            {
                //If player currently don't have the product ready to serve, return
                if (!PlayerSlots.HoldsItem(orderID))
                {
                    return;
                }

                
                total_order_served++;

                Debug.Log("Served one thing");

                if (order_count == total_order_served)
                {
                    Debug.Log("customer is happy");
                    //We served the order, we need to raise the relevant event;
                    OrderCompleted();
                }
            }
        }

        public void OrderCompleted()
        {
            isComplete = true;
            //We completed the order,
            //For demo purposes we will just calculate our success based on the serve-time we got
            float success = curServeTime / totalServingTime;

            
            //we could of course calculate this on various parameters affecting
            //this success value i.e. cooking amount, speed, combo multiplier,
            //combo multipliers of same product in a row or customer happiness

            BasicGameEvents.RaiseOnOrderCompleted(orderID, success, isSpecialOrder);

            
            //Destroy(gameObject);
            StartCoroutine(DoEmphasize());

        }


        public IEnumerator DoEmphasize()
        {
            //You can do a better version of this with DOTween punchscale;
            var outline = m_Image.GetComponent<Outline>();
            Color outlineColor = outline.effectColor;
            float totalTime = .6f;
            float curTime = totalTime;
            var alphaVal = 1f;
            isOrdering = true;
            while (curTime > 0)
            {
                curTime -= Time.deltaTime;

                transform.localScale += Vector3.one * 0.1f * -1f * Mathf.Sin(totalTime - 2 * curTime);
                //animate outline alpha
                alphaVal += 0.1f * -1f * Mathf.Sin(totalTime - 2 * curTime);
                outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, alphaVal);

                if (GameManager.instance.isPaused)
                {
                    transform.localScale = Vector3.one;
                    outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0f);
                }
                yield return null;
            }

            transform.localScale = Vector3.one;
            outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0f);
            isOrdering = false;
            Destroy(gameObject);

        }

        public void SetOrder(int ID, float serveTime, bool isSpecial)
        {
            orderID = ID;
            totalServingTime = serveTime;
            curServeTime = totalServingTime;
            isSpecialOrder = isSpecial;


            //If totalserving time has passed we cancel the order
            //So we set a delayed invoke with serveTime here.
            
            
        }

        public void SetSprite(Sprite sprite)
        {
            //Because this is a one time only approach , we dont need to get reference to the sprite,
            //If you have another use case for the sprite and you'll use it more than once
            //Its a better idea to hold a reference to the sprite and get it on OnEnable or Start functions;

            m_Image = transform.GetChild(0).GetComponent<Image>();
            m_Image.sprite = sprite;
        }

        public void Update()
        {
            //we can also check for cancel time here but we don't need to.
            if (!GameManager.instance.isGameOver)
            {
                if (!GameManager.instance.isPaused)
                {
                    StartCoroutine(ServeTime());
                }

                else
                    return;
            }

            else
            {
                return;
            }

            

            
            
        }

        IEnumerator ServeTime()
        {
            

            //Update the UI progress bar
            //by finding how much time we have and divide by total time
            //Fill amounts are great for progress bars,
            //You can do a lot of UI tricks, just by using the fill mode of a UI sprite.

            if (serveTimeRepresentation != null)
            {
                if (!isComplete)
                {
                    curServeTime -= Time.deltaTime;
                    serveTimeRepresentation.fillAmount = curServeTime / totalServingTime;
                    
                    if (serveTimeRepresentation.fillAmount <= 0)
                    {
                        CancelOrder();
                    }
                }
                if (isComplete)
                    yield return null;

            }

            else
            {
                print("End order");
            }

            yield return null;
        }

        public void CancelOrder()
        {
            if (isOrdering)
                return;
            BasicGameEvents.RaiseOnOrderCancelled(orderID);
            //Order is canncelled so destroy the UI object.
            Destroy(gameObject);


        }
    }
}