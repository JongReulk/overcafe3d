using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class todaymenu : MonoBehaviour
{
    public GameObject[] recommendMenu;
    private int randomMenu;
    // Start is called before the first frame update
    void Start()
    {
        randomMenu = Random.Range(0, 4);
        for(int i = 0; i < recommendMenu.Length; i++)
        {
            recommendMenu[i].SetActive(false);
        }
        recommendMenu[randomMenu].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
