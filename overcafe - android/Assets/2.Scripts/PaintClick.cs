using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintClick : MonoBehaviour
{
    int click_num;
    // Start is called before the first frame update
    void Start()
    {
        click_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        click_num += 1;
        
        if(click_num == 10)
        {
            GameManager.instance.scoreResult += 50;
            soundManager.instance.isAchieved = true;
        }
    }
}
