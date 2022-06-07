using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera_4stage : MonoBehaviour
{
    [Header("Camera")]
    
    public Camera LeftCamera_4;
    public Camera RightCamera_4;

    public Button LeftCursor_4;
    public Button RightCursor_4;

    private int stage;

    private void Awake()
    {
        if (GameManager.instance.isPaused)
        {
            LeftCursor_4.interactable = false;
            RightCursor_4.interactable = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        stage = PlayerPrefs.GetInt("Stage");

        
        if (stage == 4)
        {
            LeftCamera_4.enabled = false;

            RightCamera_4.enabled = true;

            LeftCursor_4.interactable = true;

            RightCursor_4.interactable = false;


        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickOnLeftCursor_4()
    {
        
        if (RightCamera_4 != null)
        {
            if (RightCamera_4.enabled)
            {
                RightCamera_4.enabled = false;
                LeftCamera_4.enabled = true;

                LeftCursor_4.interactable = false;
                RightCursor_4.interactable = true;
            }
        }


    }

    public void ClickOnRightCursor_4()
    {
        
        if (LeftCamera_4.enabled)
        {
            LeftCamera_4.enabled = false;
            RightCamera_4.enabled = true;

            LeftCursor_4.interactable = true;

            RightCursor_4.interactable = false;
            
            
        }
    }
}
