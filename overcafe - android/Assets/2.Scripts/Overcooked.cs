using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PW
{
    public class Overcooked : MonoBehaviour
    {
        private Color overcookedColor;

        public void overcookedHelper(bool result)
        {
            gameObject.SetActive(result);
        }

        
    }
}
