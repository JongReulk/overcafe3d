using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageTouch : MonoBehaviour
{
    public static stageTouch instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<stageTouch>();


            }

            return s_instance;
        }
    }

    private static stageTouch s_instance;

    public GameObject stageBackground;
    public GameObject stageSelect;

    public Text cafenameText;
    private string cafename;

    public GameObject[] stage_choose;

    public AudioClip StageSelectClick;
    public AudioClip StageClick;
    public AudioClip SpecialClick;
    private AudioSource StageAudio;

    public GameObject[] ClearCanvas;
    public GameObject[] notClearCanvas;
    private int stage100_levelat;
    public GameObject SecretTip;

    // Start is called before the first frame update
    void Start()
    {
        cafename = PlayerPrefs.GetString("cafename");
        StageAudio = GetComponent<AudioSource>();
        cafenameText.text = cafename;
        stageBackground.SetActive(true);
        stageSelect.SetActive(false);

        stage100_levelat = PlayerPrefs.GetInt("stage100_levelat");

        if(stage100_levelat == 1)
        {
            for (int i=0; i < ClearCanvas.Length; i++)
            {
                ClearCanvas[i].SetActive(true);
                notClearCanvas[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < ClearCanvas.Length; i++)
            {
                ClearCanvas[i].SetActive(false);
                notClearCanvas[i].SetActive(true);
            }
        }



        for (int i = 0; i <stage_choose.Length; i++)
        {
            stage_choose[i].SetActive(false);
        }

        stage_choose[0].SetActive(true);
    }

    public void ClickOnStageStartClick()
    {
        StageAudio.PlayOneShot(StageSelectClick);
        stageBackground.SetActive(false);
        stageSelect.SetActive(true);
    }

    public void ClickOnStageHomeButton()
    {
        StageAudio.PlayOneShot(StageSelectClick);
        stageBackground.SetActive(true);
        stageSelect.SetActive(false);
    }

    public void ClickOnStage1()
    {
        for (int i = 0; i < stage_choose.Length; i++)
        {
            stage_choose[i].SetActive(false);
        }
        StageAudio.PlayOneShot(StageSelectClick);

        stage_choose[1].SetActive(true);
    }

    public void ClickOnStage2()
    {
        for (int i = 0; i < stage_choose.Length; i++)
        {
            stage_choose[i].SetActive(false);
        }
        StageAudio.PlayOneShot(StageSelectClick);

        stage_choose[2].SetActive(true);
    }

    public void ClickOnStage3()
    {
        for (int i = 0; i < stage_choose.Length; i++)
        {
            stage_choose[i].SetActive(false);
        }
        StageAudio.PlayOneShot(StageSelectClick);

        stage_choose[3].SetActive(true);
    }

    public void ClickOnStage4()
    {
        for (int i = 0; i < stage_choose.Length; i++)
        {
            stage_choose[i].SetActive(false);
        }
        StageAudio.PlayOneShot(StageSelectClick);

        stage_choose[4].SetActive(true);
    }

    public void StageSoundOn()
    {
        StageAudio.PlayOneShot(StageClick);
    }

    public void StageSelectOn()
    {
        StageAudio.PlayOneShot(StageSelectClick);
    }

    public void SpecialClickOn()
    {
        StageAudio.PlayOneShot(SpecialClick);
    }

    public void ClickOnSecretTip()
    {
        SecretTip.SetActive(true);
    }
    public void ClickOnSecretTipOK()
    {
        SecretTip.SetActive(false);
    }
}
