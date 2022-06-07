using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{

    [Header("Camera")]
    public Camera DefaultCamera;
    public Camera LeftCamera;
    public Camera RightCamera;
    
    public Button LeftCursor;
    public Button RightCursor;

    private int stage;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        stage = PlayerPrefs.GetInt("Stage");

        

        

        if (stage == 2)
        {
            if (LeftCamera != null)
            {
                LeftCamera.enabled = true;
                LeftCursor.interactable = false;
            }
            if (RightCamera != null)
            {
                RightCamera.enabled = false;
                RightCursor.interactable = false;
            }
            DefaultCamera.enabled = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        

       
    }

    public void CameraCursorEnable()
    {
        if (stage == 2)
        {
            if (LeftCamera != null)
            {
                LeftCamera.enabled = true;
                LeftCursor.interactable = false;
            }
            if (RightCamera != null)
            {
                RightCamera.enabled = false;
                RightCursor.interactable = false;
            }
            DefaultCamera.enabled = false;
        }
    }

    public void ClickOnLeftCursor()
    {
        if (DefaultCamera.enabled)
        {
            DefaultCamera.enabled = false;
            LeftCamera.enabled = true;
            LeftCursor.interactable = false;
            RightCursor.interactable = true;
        }

        if (RightCamera != null)
        {
            if (RightCamera.enabled)
            {
                RightCamera.enabled = false;
                DefaultCamera.enabled = true;
                LeftCursor.interactable = true;
                RightCursor.interactable = true;
            }
        }


    }

    public void ClickOnRightCursor()
    {
        if (DefaultCamera.enabled)
        {
            DefaultCamera.enabled = false;
            RightCamera.enabled = true;
            RightCursor.interactable = false;
        }

        if (LeftCamera.enabled)
        {
            LeftCamera.enabled = false;
            DefaultCamera.enabled = true;
            LeftCursor.interactable = true;
            if (stage == 2)
                RightCursor.interactable = false;
            else
                RightCursor.interactable = true;
        }
    }
}
