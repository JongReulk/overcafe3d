using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageSelectCamera : MonoBehaviour
{
    [Header("Camera")]

    public Camera[] stage_camera;
    
    public Button m_LeftCursor;
    public Button m_RightCursor;

    private int stage;
    // Start is called before the first frame update
    void Start()
    {
        stage = PlayerPrefs.GetInt("Stage",1);

        print(stage);

        for(int i = 0; i < stage_camera.Length; i++)
        {
            stage_camera[i].enabled = false;
        }

        if(stage == 1 || stage == 0)
        {
            stage_camera[0].enabled = true;
            m_LeftCursor.interactable = false;
            m_RightCursor.interactable = true;
        }
        if (stage == 2)
        {
            stage_camera[1].enabled = true;
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = true;
        }
        if (stage == 3)
        {
            stage_camera[2].enabled = true;
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = true;
        }
        if (stage == 4)
        {
            stage_camera[3].enabled = true;
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = false;
        }

        if (stage == 100)
        {
            stage_camera[3].enabled = true;
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnStagePrevious()
    {
        //soundManager.instance.isClick = true;
        if (stage_camera[1].enabled == true)
        {
            m_LeftCursor.interactable = false;
            m_RightCursor.interactable = true;
            stage_camera[1].enabled = false;
            stage_camera[0].enabled = true;
        }

        if (stage_camera[2].enabled == true)
        {
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = true;
            stage_camera[2].enabled = false;
            stage_camera[1].enabled = true;
        }

        if (stage_camera[3].enabled == true)
        {
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = true;
            stage_camera[3].enabled = false;
            stage_camera[2].enabled = true;
        }


    }

    public void ClickOnStageNext()
    {
        //soundManager.instance.isClick = true;
        if (stage_camera[2].enabled == true)
        {
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = false;
            stage_camera[2].enabled = false;
            stage_camera[3].enabled = true;
        }

        if (stage_camera[1].enabled == true)
        {
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = true;
            stage_camera[1].enabled = false;
            stage_camera[2].enabled = true;
        }

        if (stage_camera[0].enabled == true)
        {
            m_LeftCursor.interactable = true;
            m_RightCursor.interactable = true;
            stage_camera[0].enabled = false;
            stage_camera[1].enabled = true;
        }
    }
}
