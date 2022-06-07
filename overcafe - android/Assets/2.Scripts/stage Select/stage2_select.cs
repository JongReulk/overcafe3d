using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2_select : MonoBehaviour
{
    private int stage2_1_score;
    private int stage2_2_score;
    private int stage2_3_score;
    private int stage2_4_score;
    private int stage2_5_score;
    private int stage2_6_score;

    private int score2_1_star;
    private int score2_2_star;
    private int score2_3_star;
    private int score2_4_star;
    private int score2_5_star;
    private int score2_6_star;


    private int stage2_levelat;
    private int stage3_levelat;

    [Header("Star")]
    public GameObject[] stage2_1_star;
    public GameObject[] stage2_2_star;
    public GameObject[] stage2_3_star;
    public GameObject[] stage2_4_star;
    public GameObject[] stage2_5_star;
    public GameObject[] stage2_6_star;

    [Header("Stage Idle")]
    public GameObject[] stageIdle_2;

    [Header("Stage Confirm")]
    public GameObject[] stageConfirm_2;

    [Header("Stage Lock")]
    public GameObject[] stageLock_2;
    // [0] -> stage, [1] -> confirm, [3] -> lock

    //public Button[] Clearstage;


    // Start is called before the first frame update
    void Start()
    {
        score2_1_star = PlayerPrefs.GetInt("score_2_1_star", 0);
        score2_2_star = PlayerPrefs.GetInt("score_2_2_star", 0);
        score2_3_star = PlayerPrefs.GetInt("score_2_3_star", 0);
        score2_4_star = PlayerPrefs.GetInt("score_2_4_star", 0);
        score2_5_star = PlayerPrefs.GetInt("score_2_5_star", 0);
        score2_6_star = PlayerPrefs.GetInt("score_2_6_star", 0);

        stage2_levelat = PlayerPrefs.GetInt("stage2_levelat", 0);
        stage3_levelat = PlayerPrefs.GetInt("stage3_levelat", 0);



        #region stage2_levelat
        if (stage2_levelat < 2)
        {
            if (score2_1_star > 0)
            {
                PlayerPrefs.SetInt("stage2_levelat", 2);
            }
        }

        if (stage2_levelat < 3)
        {
            if (score2_2_star > 0)
            {
                PlayerPrefs.SetInt("stage2_levelat", 3);
            }
        }

        if (stage2_levelat < 4)
        {
            if (score2_3_star > 0)
            {
                PlayerPrefs.SetInt("stage2_levelat", 4);
            }
        }

        if (stage2_levelat < 5)
        {
            if (score2_4_star > 0)
            {
                PlayerPrefs.SetInt("stage2_levelat", 5);
            }
        }

        if (stage2_levelat < 6)
        {
            if (score2_5_star > 0)
            {
                PlayerPrefs.SetInt("stage2_levelat", 6);
            }
        }

        if (stage2_levelat < 7)
        {
            if (score2_6_star > 0)
            {
                PlayerPrefs.SetInt("stage2_levelat", 6);
                if (stage3_levelat == 0)
                {
                    PlayerPrefs.SetInt("stage3_levelat", 1);
                }
            }
        }
        #endregion

        stage2_levelat = PlayerPrefs.GetInt("stage2_levelat", 0);
        Debug.Log("Stage2_level at " + stage2_levelat);

        for (int i = 0; i < stageIdle_2.Length; i++)
        {
            stageIdle_2[i].SetActive(false);
            stageConfirm_2[i].SetActive(false);
            stageLock_2[i].SetActive(true);
        }

        /*
        for (int i = 0; i < stage1_levelat; i++)
        {
            stageLock[i].SetActive(false);
            stageIdle[i].SetActive(true);
        }
        */

        for (int i = 0; i < stage2_levelat; i++)
        {
            stageLock_2[i].SetActive(false);
            stageIdle_2[i].SetActive(true);
        }


        #region star
        for (int i = 0; i < score2_1_star; i++)
        {
            stage2_1_star[i].SetActive(true);
        }

        for (int i = 0; i < score2_2_star; i++)
        {
            stage2_2_star[i].SetActive(true);
        }

        for (int i = 0; i < score2_3_star; i++)
        {
            stage2_3_star[i].SetActive(true);
        }

        for (int i = 0; i < score2_4_star; i++)
        {
            stage2_4_star[i].SetActive(true);
        }

        for (int i = 0; i < score2_5_star; i++)
        {
            stage2_5_star[i].SetActive(true);
        }

        for (int i = 0; i < score2_6_star; i++)
        {
            stage2_6_star[i].SetActive(true);
        }

        #endregion

    }

    #region ClickImage definition
    public void ClickOn2_1Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_2[0].SetActive(false);
        stageConfirm_2[0].SetActive(true);
    }

    public void ClickOn2_2Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_2[1].SetActive(false);
        stageConfirm_2[1].SetActive(true);
    }

    public void ClickOn2_3Image()
    {
        stageTouch.instance.SpecialClickOn();
        stageIdle_2[2].SetActive(false);
        stageConfirm_2[2].SetActive(true);
    }

    public void ClickOn2_4Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_2[3].SetActive(false);
        stageConfirm_2[3].SetActive(true);
    }

    public void ClickOn2_5Image()
    {
        stageTouch.instance.SpecialClickOn();
        stageIdle_2[4].SetActive(false);
        stageConfirm_2[4].SetActive(true);
    }

    public void ClickOn2_6Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_2[5].SetActive(false);
        stageConfirm_2[5].SetActive(true);
    }
    #endregion

    #region ClickNo definition
    public void ClickOn2_1no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_2[0].SetActive(true);
        stageConfirm_2[0].SetActive(false);
    }

    public void ClickOn2_2no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_2[1].SetActive(true);
        stageConfirm_2[1].SetActive(false);
    }

    public void ClickOn2_3no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_2[2].SetActive(true);
        stageConfirm_2[2].SetActive(false);
    }

    public void ClickOn2_4no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_2[3].SetActive(true);
        stageConfirm_2[3].SetActive(false);
    }

    public void ClickOn2_5no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_2[4].SetActive(true);
        stageConfirm_2[4].SetActive(false);
    }

    public void ClickOn2_6no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_2[5].SetActive(true);
        stageConfirm_2[5].SetActive(false);
    }
    #endregion

    #region ClickYes definition
    public void ClickOn2_1yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage2_1");
        AdmobBanner.instance.DestroyAd();
        //SceneManager.LoadScene("Loading");
    }

    public void ClickOn2_2yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage2_2");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn2_3yes()
    {
        stageTouch.instance.SpecialClickOn();
        SceneLoad.LoadScene("newStage2_3");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn2_4yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage2_4");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn2_5yes()
    {
        stageTouch.instance.SpecialClickOn();
        SceneLoad.LoadScene("newStage2_5");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn2_6yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage2_6");
        AdmobBanner.instance.DestroyAd();
    }

    #endregion
}
