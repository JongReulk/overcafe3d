// ******------------------------------------------------------******
// OrderGenerator.cs
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
// ******------------------------------------------------------******

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

namespace PW
{
    public class OrderGenerator : MonoBehaviour
    {
        //This limits generating orders constantly
        public int MaxConcurrentOrder=3;

        public int currentOrderCount;

        public Sprite[] orderSprites;

        private AudioSource OrderSound;

        private int tips;

        private int multitips;

        public bool isSpecial;

        private int isTutorial;
        private int productNum;

        private int stageNum;

        

        //[HideInInspector]
        public int[] orderedProducts;

        public Transform UIParentForOrders;
        
        public GameObject orderRepPrefab;//The general prefab for order represantation

        public GameObject specialOrderPrefab;

        private void OnEnable()
        {
            //We'll listen for order events;
            BasicGameEvents.onOrderCancelled += BasicGameEvents_onOrderCancelled;
            BasicGameEvents.onOrderCompleted += BasicGameEvents_onOrderCompleted;
            stageNum = PlayerPrefs.GetInt("Stage", 0);

        }
        private void OnDisable()
        {
            //Don't forget to remove listeners from events on disable.
            BasicGameEvents.onOrderCancelled -= BasicGameEvents_onOrderCancelled;
            BasicGameEvents.onOrderCompleted -= BasicGameEvents_onOrderCompleted;

        }

        public bool isSpecialOrder()
        {
            return isSpecial = true;
        }

        private void BasicGameEvents_onOrderCancelled(int ID)
        {
            //We could also do something with the ID of the product,
            //Or we could pass other things as parameters,
            //but for demo purposes this is fine.
            if(isTutorial == 0)
            {
                soundManager.instance.isFailed = true;
                currentOrderCount--;
                return;
            }

            if(stageNum == 200 || stageNum == 250)
            {
                soundManager.instance.isFailed = true;
                GameManager.instance.isGameOver = true;
            }
            
            if (!GameManager.instance.isGameOver)
            {
                soundManager.instance.isFailed = true;
                GameManager.instance.combo = 0;
                GameManager.instance.scoreResult -= 10;
                currentOrderCount--;
            }

        }

        private void BasicGameEvents_onOrderCompleted(int ID,float percentageSucccess, bool isSpecial)
        {
            if (isTutorial == 0)
            {
                soundManager.instance.isAchieved = true;
                multitips = GameManager.instance.multiTip;
                tips = Mathf.FloorToInt(percentageSucccess * 10);
                currentOrderCount--;
                GameManager.instance.isOrderSuccess = true;
                soundManager.instance.isAchieved = true;

                GameManager.instance.combo++;
                tips = tips * multitips;
                GameManager.instance.scoreResult += 10 + tips;
                GameManager.instance.tip = tips;
                if (productNum == 4)
                {
                    PlayerPrefs.SetInt("productNum", 6);
                    productNum = 6;
                }

                if (productNum == 2)
                {
                    PlayerPrefs.SetInt("productNum", 4);
                    productNum = 4;
                }

                if (productNum == 0)
                {
                    //Fungus.Flowchart.BroadcastFungusMessage("Success!");
                    PlayerPrefs.SetInt("productNum", 2);
                    productNum = 2;
                }

                

                


            }

            else
            {
                // 주문 성공했을 경우
                if (!GameManager.instance.isGameOver)
                {
                    multitips = GameManager.instance.multiTip;
                    Debug.Log("스페셜 ?" + isSpecial);
                    tips = Mathf.FloorToInt(percentageSucccess * 10);
                    currentOrderCount--;
                    GameManager.instance.isOrderSuccess = true;
                    soundManager.instance.isAchieved = true;

                    if (isSpecial)
                    {
                        GameManager.instance.combo++;
                        tips = tips * multitips;
                        GameManager.instance.scoreResult += 20 + tips;
                        GameManager.instance.tip = tips;
                    }
                    else
                    {
                        GameManager.instance.combo++;
                        tips = tips * multitips;
                        GameManager.instance.scoreResult += 10 + tips;
                        GameManager.instance.tip = tips;
                    }
                }
            }
            

            //In a common gameplay logic,
            //We would add money, play effects, maybe check our list of products to complete here,
            //by raising an another event or calling a method of a gamemanager like script.
            //i.e. GameManager.CheckMilestonesForOrderID(ID)
            //or BasicGameEvents.onMoneyIncreased(ID,percentageSuccess)
            //percentage of Success can define the xp we got, or money multiplier and so forth.


            //You could also use another float as a third parameter to check if an order is overcooked,
            //or just perfect.
            //You could also check combo multipliers for multiple fast deliveries
        }


        void Start()
        {
            //In a demo only manner we start calling the coroutine here on Start.
            isTutorial = PlayerPrefs.GetInt("isTutorial", 0);
            productNum = 0;

            StartCoroutine(GenerateOrderRoutine(4f));

            

        }


        public IEnumerator GenerateOrderRoutine(float intervalTime)
        {
            //We assume we don't pause the game or something,
            //You should check if your game state is playing here
            while (true)
            {

                
                if (currentOrderCount < MaxConcurrentOrder)
                {
                    
                    if (isTutorial == 0)
                    {
                        intervalTime = 0f;
                        TutorialGenerateOrder();
                        yield return new WaitForSeconds(intervalTime);
                    }
                    else
                    {
                        
                        int orderRandom = Random.Range(0, 6);
                        
                        //print(orderRandom);
                        intervalTime = Random.Range(3f, 5f);

                        if (stageNum == 250)
                        {
                            intervalTime = Random.Range(3f, 3.5f);
                        }

                        if (orderRandom == 0 )
                        {
                            SpecialGenerateOrder();
                            yield return new WaitForSeconds(intervalTime);
                        }
                        else
                        {
                            GenerateOrder();
                            yield return new WaitForSeconds(intervalTime);
                        }
                    }
                }

                else
                {
                    yield return new WaitForEndOfFrame();
                    //yield return null;
                }
                

                
            }
        }

        public void GenerateOrder()
        {
            
            if (!GameManager.instance.isPaused)
            {
                //Debug.Log(GameManager.instance.isPaused);
                Debug.Log("Generating order");

                int spriteIndex = Random.Range(0, orderSprites.Length);
                
                int orderID = orderedProducts[spriteIndex];
                
                var newOrder = GameObject.Instantiate(orderRepPrefab, UIParentForOrders).GetComponent<ServeOrder>();

                if(stageNum == 250)
                {
                    newOrder.SetOrder(orderID, Random.Range(15f, 17f), false);
                    print("HARD!");
                }

                else
                {
                    newOrder.SetOrder(orderID, Random.Range(20f, 22f), false);
                }
                

                newOrder.SetSprite(orderSprites[spriteIndex]);

                soundManager.instance.isOrder = true;

                currentOrderCount++;
                
            }
            //Get a random ID from sprites list
            //We could store the ID of the object to track last generated orders,
            //Totally random generation may create the same order in row repeatedly.
            else
            {
                return;
            }


        }

        public void SpecialGenerateOrder()
        {
            
            if (!GameManager.instance.isPaused)
            {
                //Debug.Log(GameManager.instance.isPaused);
                Debug.Log("Generating Special order");

                int spriteIndex = Random.Range(0, orderSprites.Length);

                
                
                int orderID = orderedProducts[spriteIndex];
                

                var newOrder = GameObject.Instantiate(specialOrderPrefab, UIParentForOrders).GetComponent<ServeOrder>();

                if (stageNum == 250)
                {
                    newOrder.SetOrder(orderID, Random.Range(13f, 15f), false);
                }

                else
                {
                    newOrder.SetOrder(orderID, Random.Range(15f, 17f), false);
                }

                

                newOrder.SetSprite(orderSprites[spriteIndex]);

                soundManager.instance.isSpecialOrder = true;
                

                currentOrderCount++;

            }
            //Get a random ID from sprites list
            //We could store the ID of the object to track last generated orders,
            //Totally random generation may create the same order in row repeatedly.
            else
            {
                return;
            }


        }

        public void TutorialGenerateOrder()
        {

            if (!GameManager.instance.isPaused)
            {
                //Debug.Log(GameManager.instance.isPaused);
                

                if (productNum == 0)
                {
                    int spriteIndex = 1;

                    int orderID = orderedProducts[spriteIndex];

                    var newOrder = GameObject.Instantiate(orderRepPrefab, UIParentForOrders).GetComponent<ServeOrder>();

                    newOrder.SetOrder(orderID, Random.Range(30f, 30f), false);

                    newOrder.SetSprite(orderSprites[spriteIndex]);

                    soundManager.instance.isOrder = true;

                    currentOrderCount++;

                    PlayerPrefs.SetInt("productNum", 0);

                    Fungus.Flowchart.BroadcastFungusMessage("Cupcake!");
                    Debug.Log("Cupcake!");
                }

                if (productNum == 2)
                {
                    int spriteIndex = 0;

                    int orderID = orderedProducts[spriteIndex];

                    var newOrder = GameObject.Instantiate(orderRepPrefab, UIParentForOrders).GetComponent<ServeOrder>();

                    newOrder.SetOrder(orderID, Random.Range(30f, 30f), false);

                    newOrder.SetSprite(orderSprites[spriteIndex]);

                    soundManager.instance.isOrder = true;

                    currentOrderCount++;

                    PlayerPrefs.SetInt("productNum", 2);

                    Fungus.Flowchart.BroadcastFungusMessage("espresso!");
                    Debug.Log("espresso!");
                }

                if (productNum == 4)
                {
                    int spriteIndex = 2;

                    int orderID = orderedProducts[spriteIndex];

                    var newOrder = GameObject.Instantiate(orderRepPrefab, UIParentForOrders).GetComponent<ServeOrder>();

                    newOrder.SetOrder(orderID, Random.Range(30f, 30f), false);

                    newOrder.SetSprite(orderSprites[spriteIndex]);

                    soundManager.instance.isOrder = true;

                    currentOrderCount++;

                    PlayerPrefs.SetInt("productNum", 4);

                    Fungus.Flowchart.BroadcastFungusMessage("Toast!");
                    Debug.Log("Toast!");
                }

                if (productNum == 6)
                {
                    currentOrderCount++;
                    PlayerPrefs.SetInt("productNum", 10);
                    Fungus.Flowchart.BroadcastFungusMessage("Done!");
                    Debug.Log("Done!");
                }

            }
            //Get a random ID from sprites list
            //We could store the ID of the object to track last generated orders,
            //Totally random generation may create the same order in row repeatedly.
            else
            {
                return;
            }


        }

        public Sprite GetSpriteForOrder(int orderID)
        {
            var spriteIndex = Array.IndexOf(orderedProducts, orderID);
            if (spriteIndex<0)
                return null;
            return orderSprites[spriteIndex];
        }

        
    }
}