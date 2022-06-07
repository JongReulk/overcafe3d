using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera_final : MonoBehaviour
{
    [Header("Camera")]

    public Camera DefaultCamera_final;
    public Camera LeftCamera_final;
    public Camera RightCamera_final;
    public Camera Right_right_Camera_final;

    public Button LeftCursor_final;
    public Button RightCursor_final;

    

    private int stage;

    // Start is called before the first frame update
    void Start()
    {

        stage = PlayerPrefs.GetInt("Stage");

        DefaultCamera_final.enabled = true;
        
        LeftCamera_final.enabled = false;

        RightCamera_final.enabled = false;

        Right_right_Camera_final.enabled = false;


        LeftCursor_final.interactable = true;

        RightCursor_final.interactable = true;


        



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnLeftCursor_final()
    {
        if (DefaultCamera_final.enabled)
        {
            DefaultCamera_final.enabled = false;
            RightCamera_final.enabled = false;
            LeftCamera_final.enabled = true;
            Right_right_Camera_final.enabled = false;

            LeftCursor_final.interactable = false;
            RightCursor_final.interactable = true;

            return;
        }

        

        if (RightCamera_final.enabled)
        {
            DefaultCamera_final.enabled = true;
            RightCamera_final.enabled = false;
            LeftCamera_final.enabled = false;
            Right_right_Camera_final.enabled = false;

            LeftCursor_final.interactable = true;
            RightCursor_final.interactable = true;

            return;
        }

        if (Right_right_Camera_final.enabled)
        {
            DefaultCamera_final.enabled = false;
            RightCamera_final.enabled = true;
            LeftCamera_final.enabled = false;
            Right_right_Camera_final.enabled = false;

            LeftCursor_final.interactable = true;
            RightCursor_final.interactable = true;

            return;
        }



    }

    public void ClickOnRightCursor_final()
    {

        if (DefaultCamera_final.enabled)
        {
            DefaultCamera_final.enabled = false;
            RightCamera_final.enabled = true;
            LeftCamera_final.enabled = false;
            Right_right_Camera_final.enabled = false;

            LeftCursor_final.interactable = true;
            RightCursor_final.interactable = true;

            return;
        }

        if (LeftCamera_final.enabled)
        {
            DefaultCamera_final.enabled = true;
            RightCamera_final.enabled = false;
            LeftCamera_final.enabled = false;
            Right_right_Camera_final.enabled = false;

            LeftCursor_final.interactable = true;
            RightCursor_final.interactable = true;

            return;
        }


        if (RightCamera_final.enabled)
        {
            DefaultCamera_final.enabled = false;
            RightCamera_final.enabled = false;
            LeftCamera_final.enabled = false;
            Right_right_Camera_final.enabled = true;

            LeftCursor_final.interactable = true;
            RightCursor_final.interactable = false;

            return;
        }

        
    }
}
