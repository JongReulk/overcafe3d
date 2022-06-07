using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PW
{

    public class SetableProduct : ProductGameObject
    {
        public GameObject platePrefab;
        
        Collider m_collider;

        public int first_set_a;
        public int second_set_b;

        private void Awake()
        {

            m_collider = GetComponent<Collider>();
            m_collider.enabled = true;
        }

        void OnMouseDown()
        {
            if (!GameManager.instance.isPaused)
            {
                if (!base.CanGoPlayerSlot())
                {
                    return;
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

            yield return base.AnimateGoingToSlot();

            gameObject.SetActive(false);
        }

    
    }
}
