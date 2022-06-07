using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    public GameObject BackTotitle;
    private int isEnd;
    // Start is called before the first frame update
    void Start()
    {
        isEnd = PlayerPrefs.GetInt("IsEnd", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void SetBackToMenu()
    {
        PlayerPrefs.SetInt("IsEnd", 1);
        BackTotitle.SetActive(true);
    }
}
