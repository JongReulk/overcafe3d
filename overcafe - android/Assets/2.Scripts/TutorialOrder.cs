using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace PW
{
    public class TutorialOrder : MonoBehaviour
    {
        //This limits generating orders constantly
        public int MaxConcurrentOrder = 3;

        public int currentOrderCount;

        public Sprite[] orderSprites;

        private AudioSource OrderSound;

        private int tips;

        private int multitips;

        public bool isSpecial;

        [HideInInspector]
        public int[] orderedProducts;

        public Transform UIParentForOrders;

        public GameObject orderRepPrefab;//The general prefab for order represantation

        public GameObject specialOrderPrefab;

        private int productNum;

        

        private void OnEnable()
        {
            //We'll listen for order events;
            BasicGameEvents.onOrderCancelled += BasicGameEvents_onOrderCancelled;
            BasicGameEvents.onOrderCompleted += BasicGameEvents_onOrderCompleted;

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
            if (!GameManager.instance.isGameOver)
            {
                soundManager.instance.isFailed = true;
                GameManager.instance.combo = 0;
                GameManager.instance.scoreResult -= 10;
                currentOrderCount--;
            }

        }

        private void BasicGameEvents_onOrderCompleted(int ID, float percentageSucccess, bool isSpecial)
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
                    
                    GenerateOrder();
                    yield return new WaitForSeconds(intervalTime);
                    
                    
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

                if (productNum == 0)
                {
                    //int spriteIndex = 0;
                    int spriteIndex = Random.Range(0, orderSprites.Length);

                    int orderID = orderedProducts[spriteIndex];

                    var newOrder = GameObject.Instantiate(orderRepPrefab, UIParentForOrders).GetComponent<ServeOrder>();

                    Debug.Log("Cupcake!");

                    newOrder.SetOrder(orderID, Random.Range(14f, 20f), false);

                    newOrder.SetSprite(orderSprites[spriteIndex]);

                    soundManager.instance.isOrder = true;

                    currentOrderCount++;
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

        public void SpecialGenerateOrder()
        {

            if (!GameManager.instance.isPaused)
            {
                //Debug.Log(GameManager.instance.isPaused);
                Debug.Log("Generating Special order");

                int spriteIndex = Random.Range(0, orderSprites.Length);

                int orderID = orderedProducts[spriteIndex];

                var newOrder = GameObject.Instantiate(specialOrderPrefab, UIParentForOrders).GetComponent<ServeOrder>();

                newOrder.SetOrder(orderID, Random.Range(14f, 20f), true);

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

        public Sprite GetSpriteForOrder(int orderID)
        {
            var spriteIndex = Array.IndexOf(orderedProducts, orderID);
            if (spriteIndex < 0)
                return null;
            return orderSprites[spriteIndex];
        }
    }
}
