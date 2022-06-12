// ******------------------------------------------------------******
// PlayerSlots.cs
//
// PlayerSlots is some kind of a inventory mechanism. 
// When player has a product or thing in their hands, we add the item to slots.
//
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
// ******------------------------------------------------------******
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace PW
{
    public class PlayerSlots : MonoBehaviour
    {
        public int slotCount;

        //Player holds order ID's of items in those slots;
        int[] slotItems;

        public Image[] slotUIObjects;

        private void OnEnable()
        {
            

            if (slotItems == null)
                slotItems = new int[3] { -1, -1, -1 };

            BasicGameEvents.onProductAddedToSlot += BasicGameEvents_onProductAddedToSlot;
            BasicGameEvents.onProductDeletedFromSlot += BasicGameEvents_onProductDeletedFromSlot;
            
        }

        private void BasicGameEvents_onProductDeletedFromSlot(int ID)
        {
            if(slotItems!=null && slotItems.Length>0)
                slotItems[ID]=-1;
        }

        private void BasicGameEvents_onProductAddedToSlot(int orderID)
        {
            var orderGenerator = FindObjectOfType<OrderGenerator>();

            var isCupcakeCherry = Array.IndexOf(slotItems, 100);
            var isCupcakeOreo = Array.IndexOf(slotItems, 101);

            var isDoughnutblack = Array.IndexOf(slotItems, 200);
            var isDoughnutpink = Array.IndexOf(slotItems, 201);
            var isDoughnutwhite = Array.IndexOf(slotItems, 202);

            var isCookie = Array.IndexOf(slotItems, 300);
            var isToastegg = Array.IndexOf(slotItems, 301);
            var isToastcherry = Array.IndexOf(slotItems, 302);
            var isToastolives = Array.IndexOf(slotItems, 303);
            var isToastoranges = Array.IndexOf(slotItems, 304);

            var isCookieSet = Array.IndexOf(slotItems, 18);

            var isCakeblueberry = Array.IndexOf(slotItems, 400);
            var isCakestrawberry = Array.IndexOf(slotItems, 401);

            var isCakeSet = Array.IndexOf(slotItems, 25);
            var isThreeCakeSet = Array.IndexOf(slotItems, 27);




            int isEspresso = Array.IndexOf(slotItems, 1);
            int isMochapot = Array.IndexOf(slotItems, 9);
            int isTea = Array.IndexOf(slotItems, 17);
            //Debug.Log("IsEspresso" + isEspresso);

            // 세트 만들기
            if (isCupcakeCherry >= 0)
            {
                if (orderID == 1)
                {
                    orderID = 2;
                    slotItems[isCupcakeCherry] = -1;
                    slotUIObjects[isCupcakeCherry].sprite = null;
                }
            }

            if (isCupcakeOreo >= 0)
            {
                if (orderID == 1)
                {
                    orderID = 5;
                    slotItems[isCupcakeOreo] = -1;
                    slotUIObjects[isCupcakeOreo].sprite = null;
                }
            }

            if (isDoughnutblack >= 0)
            {
                if (orderID == 9)
                {
                    orderID = 10;
                    slotItems[isDoughnutblack] = -1;
                    slotUIObjects[isDoughnutblack].sprite = null;
                }
            }

            if (isDoughnutpink >= 0)
            {
                if (orderID == 9)
                {
                    orderID = 12;
                    slotItems[isDoughnutpink] = -1;
                    slotUIObjects[isDoughnutpink].sprite = null;
                }
            }

            if (isDoughnutwhite >= 0)
            {
                if (orderID == 9)
                {
                    orderID = 13;
                    slotItems[isDoughnutwhite] = -1;
                    slotUIObjects[isDoughnutwhite].sprite = null;
                }
            }

            if (isCookie >= 0)
            {
                if (orderID == 17)
                {
                    orderID = 18;
                    slotItems[isCookie] = -1;
                    slotUIObjects[isCookie].sprite = null;
                }
            }

            if (isToastegg >= 0)
            {
                if (orderID == 17)
                {
                    orderID = 19;
                    slotItems[isToastegg] = -1;
                    slotUIObjects[isToastegg].sprite = null;
                }
            }

            if (isToastcherry >= 0)
            {
                if (orderID == 17)
                {
                    orderID = 20;
                    slotItems[isToastcherry] = -1;
                    slotUIObjects[isToastcherry].sprite = null;
                }
            }

            if (isCookieSet >= 0)
            {
                if (orderID == 303)
                {
                    orderID = 22;
                    slotItems[isCookieSet] = -1;
                    slotUIObjects[isCookieSet].sprite = null;
                }

                if (orderID == 304)
                {
                    orderID = 23;
                    slotItems[isCookieSet] = -1;
                    slotUIObjects[isCookieSet].sprite = null;
                }
            }

            if (isCakeblueberry >= 0)
            {
                if (orderID == 17)
                {
                    orderID = 24;
                    slotItems[isCakeblueberry] = -1;
                    slotUIObjects[isCakeblueberry].sprite = null;
                }

                if (orderID == 401)
                {
                    orderID = 25;
                    slotItems[isCakeblueberry] = -1;
                    slotUIObjects[isCakeblueberry].sprite = null;
                }
            }

            if (isCakeSet >= 0)
            {
                if(orderID == 17)
                {
                    orderID = 26;
                    slotItems[isCakeSet] = -1;
                    slotUIObjects[isCakeSet].sprite = null;
                }

                if (orderID == 402)
                {
                    orderID = 27;
                    slotItems[isCakeSet] = -1;
                    slotUIObjects[isCakeSet].sprite = null;
                }
            }

            if (isThreeCakeSet >= 0)
            {
                if (orderID == 17)
                {
                    orderID = 28;
                    slotItems[isThreeCakeSet] = -1;
                    slotUIObjects[isThreeCakeSet].sprite = null;
                }

                
            }







            //find the first empty index
            var emptyIndex = Array.IndexOf(slotItems, -1);
            print(emptyIndex);
            slotItems[emptyIndex] = orderID;
            slotUIObjects[emptyIndex].sprite = orderGenerator.GetSpriteForOrder(orderID);

            
            StartCoroutine(DoEmphasize(emptyIndex));
            
        }

        public IEnumerator DoEmphasize(int index)
        {
            //You can do a better version of this with DOTween punchscale;
            var uiImage = slotUIObjects[index];
            var outline = uiImage.GetComponent<Outline>();
            Color outlineColor = outline.effectColor;
            float totalTime = .6f;
            float curTime = totalTime;
            var alphaVal = 1f;
            

            while (curTime > 0)
            {
                curTime -= Time.deltaTime;
                //if (GameManager.instance.isPaused)
                //{
                   // yield break;
                //}
                uiImage.transform.localScale += Vector3.one * 0.1f * -1f * Mathf.Sin(totalTime - 2 * curTime);
                //animate outline alpha
                alphaVal += 0.1f * -1f * Mathf.Sin(totalTime - 2 * curTime);
                outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, alphaVal);

                if(GameManager.instance.isPaused)
                {
                    uiImage.transform.localScale = Vector3.one;
                    outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0f);
                }
                
                yield return null;
            }
            
            uiImage.transform.localScale = Vector3.one;
            outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0f);
            
            
        }

        private void OnDisable()
        {
            
            BasicGameEvents.onProductAddedToSlot -= BasicGameEvents_onProductAddedToSlot;
            BasicGameEvents.onProductDeletedFromSlot -= BasicGameEvents_onProductDeletedFromSlot;
            
        }


        public bool CanHoldItem(int orderID)
        {
            //you can also check for orderID here such
            //maybe you don't want to let player hold the same order more than once.

            var isCupcakeCherry = Array.IndexOf(slotItems, 100);
            var isCupcakeOreo = Array.IndexOf(slotItems, 101);

            var isDoughnutblack = Array.IndexOf(slotItems, 200);
            var isDoughnutpink = Array.IndexOf(slotItems, 201);
            var isDoughnutwhite = Array.IndexOf(slotItems, 202);

            var isCookie = Array.IndexOf(slotItems, 300);
            var isToastegg = Array.IndexOf(slotItems, 301);
            var isToastcherry = Array.IndexOf(slotItems, 302);

            var isCookieSet = Array.IndexOf(slotItems, 18);

            var isCakeblueberry = Array.IndexOf(slotItems, 400);
            var isCakestrawberry = Array.IndexOf(slotItems, 401);

            var isCakeSet = Array.IndexOf(slotItems, 25);
            var isThreeCakeSet = Array.IndexOf(slotItems, 27);

            int isEspresso = Array.IndexOf(slotItems, 1);
            int isMochapot = Array.IndexOf(slotItems, 9);
            int isTea = Array.IndexOf(slotItems, 17);

            var emptyIndex = Array.IndexOf(slotItems, -1);

            if (isCupcakeCherry >= 0)
            {
                if (orderID == 1)
                {
                    return true;
                }
            }

            if (isCupcakeOreo >= 0)
            {
                if (orderID == 1)
                {
                    return true;
                }
            }

            if (isDoughnutblack >= 0)
            {
                if (orderID == 9)
                {
                    return true;
                }
            }

            if (isDoughnutpink >= 0)
            {
                if (orderID == 9)
                {
                    return true;
                }
            }

            if (isDoughnutwhite >= 0)
            {
                if (orderID == 9)
                {
                    return true;
                }
            }

            if (isCookie >= 0)
            {
                if (orderID == 17)
                {
                    return true;
                }
            }

            if (isToastegg >= 0)
            {
                if (orderID == 17)
                {
                    return true;
                }
            }

            if (isToastcherry >= 0)
            {
                if (orderID == 17)
                {
                    return true;
                }
            }

            if (isCookieSet >= 0)
            {
                if (orderID == 303)
                {
                    return true;
                }

                if (orderID == 304)
                {
                    return true;
                }
            }

            if (isCakeblueberry >= 0)
            {
                if (orderID == 17)
                {
                    return true;
                }

                if (orderID == 401)
                {
                    return true;
                }
            }

            if (isCakeSet >= 0)
            {
                if (orderID == 17)
                {
                    return true;
                }

                if (orderID == 402)
                {
                    return true;
                }
            }

            if (isThreeCakeSet >= 0)
            {
                if (orderID == 17)
                {
                    return true;
                }
            }

            return emptyIndex >= 0;
        }

        public bool HoldsItem(int orderID)
        {

            int indexofOrder = Array.IndexOf(slotItems, orderID);
            
            if (indexofOrder == -1)
            {
                //we don't have an item with such orderID
                return false;
            }

            //remove the UI image
            slotUIObjects[indexofOrder].sprite = null;

            //Remove the slot, we just served.
            slotItems[indexofOrder] = -1;
            
            
            return true;

        }

        public void CheckSet()
        {

            
        }

        
    }
}