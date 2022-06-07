using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_select : MonoBehaviour
{
    private int stage3_1_score;
    private int stage3_2_score;
    private int stage3_3_score;
    private int stage3_4_score;
    private int stage3_5_score;
    private int stage3_6_score;

    private int score3_1_star;
    private int score3_2_star;
    private int score3_3_star;
    private int score3_4_star;
    private int score3_5_star;
    private int score3_6_star;


    private int stage3_levelat;
    private int stage4_levelat;

    [Header("Star")]
    public GameObject[] stage3_1_star;
    public GameObject[] stage3_2_star;
    public GameObject[] stage3_3_star;
    public GameObject[] stage3_4_star;
    public GameObject[] stage3_5_star;
    public GameObject[] stage3_6_star;

    [Header("Stage Idle")]
    public GameObject[] stageIdle_3;

    [Header("Stage Confirm")]
    public GameObject[] stageConfirm_3;

    [Header("Stage Lock")]
    public GameObject[] stageLock_3;
    // [0] -> stage, [1] -> confirm, [3] -> lock

    //public Button[] Clearstage;


    // Start is called before the first frame update
    void Start()
    {
        score3_1_star = PlayerPrefs.GetInt("score_3_1_star", 0);
        score3_2_star = PlayerPrefs.GetInt("score_3_2_star", 0);
        score3_3_star = PlayerPrefs.GetInt("score_3_3_star", 0);
        score3_4_star = PlayerPrefs.GetInt("score_3_4_star", 0);
        score3_5_star = PlayerPrefs.GetInt("score_3_5_star", 0);
        score3_6_star = PlayerPrefs.GetInt("score_3_6_star", 0);

        stage3_levelat = PlayerPrefs.GetInt("stage3_levelat", 0);
        stage4_levelat = PlayerPrefs.GetInt("stage4_levelat", 0);



        #region stage3_levelat
        if (stage3_levelat < 2)
        {
            if (score3_1_star > 0)
            {
                PlayerPrefs.SetInt("stage3_levelat", 2);
            }
        }

        if (stage3_levelat < 3)
        {
            if (score3_2_star > 0)
            {
                PlayerPrefs.SetInt("stage3_levelat", 3);
            }
        }

        if (stage3_levelat < 4)
        {
            if (score3_3_star > 0)
            {
                PlayerPrefs.SetInt("stage3_levelat", 4);
            }
        }

        if (stage3_levelat < 5)
        {
            if (score3_4_star > 0)
            {
                PlayerPrefs.SetInt("stage3_levelat", 5);
            }
        }

        if (stage3_levelat < 6)
        {
            if (score3_5_star > 0)
            {
                PlayerPrefs.SetInt("stage3_levelat", 6);
            }
        }

        if (stage3_levelat < 7)
        {
            if (score3_6_star > 0)
            {
                PlayerPrefs.SetInt("stage3_levelat", 6);
                if (stage4_levelat == 0)
                {
                    PlayerPrefs.SetInt("stage4_levelat", 1);
                }
            }
        }
        #endregion

        stage3_levelat = PlayerPrefs.GetInt("stage3_levelat", 0);
        Debug.Log("Stage3_level at " + stage3_levelat);
        

        for (int i = 0; i < stageIdle_3.Length; i++)
        {
            stageIdle_3[i].SetActive(false);
            stageConfirm_3[i].SetActive(false);
            stageLock_3[i].SetActive(true);
        }

        /*
        for (int i = 0; i < stage1_levelat; i++)
        {
            stageLock[i].SetActive(false);
            stageIdle[i].SetActive(true);
        }
        */

        for (int i = 0; i < stage3_levelat; i++)
        {
            stageLock_3[i].SetActive(false);
            stageIdle_3[i].SetActive(true);
        }


        #region star
        for (int i = 0; i < score3_1_star; i++)
        {
            stage3_1_star[i].SetActive(true);
        }

        for (int i = 0; i < score3_2_star; i++)
        {
            stage3_2_star[i].SetActive(true);
        }

        for (int i = 0; i < score3_3_star; i++)
        {
            stage3_3_star[i].SetActive(true);
        }

        for (int i = 0; i < score3_4_star; i++)
        {
            stage3_4_star[i].SetActive(true);
        }

        for (int i = 0; i < score3_5_star; i++)
        {
            stage3_5_star[i].SetActive(true);
        }

        for (int i = 0; i < score3_6_star; i++)
        {
            stage3_6_star[i].SetActive(true);
        }

        #endregion

    }

    #region ClickImage definition
    public void ClickOn3_1Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_3[0].SetActive(false);
        stageConfirm_3[0].SetActive(true);
    }

    public void ClickOn3_2Image()
    {
        stageTouch.instance.SpecialClickOn();
        stageIdle_3[1].SetActive(false);
        stageConfirm_3[1].SetActive(true);
    }

    public void ClickOn3_3Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_3[2].SetActive(false);
        stageConfirm_3[2].SetActive(true);
    }

    public void ClickOn3_4Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_3[3].SetActive(false);
        stageConfirm_3[3].SetActive(true);
    }

    public void ClickOn3_5Image()
    {
        stageTouch.instance.SpecialClickOn();
        stageIdle_3[4].SetActive(false);
        stageConfirm_3[4].SetActive(true);
    }

    public void ClickOn3_6Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_3[5].SetActive(false);
        stageConfirm_3[5].SetActive(true);
    }
    #endregion

    #region ClickNo definition
    public void ClickOn3_1no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_3[0].SetActive(true);
        stageConfirm_3[0].SetActive(false);
    }

    public void ClickOn3_2no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_3[1].SetActive(true);
        stageConfirm_3[1].SetActive(false);
    }

    public void ClickOn3_3no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_3[2].SetActive(true);
        stageConfirm_3[2].SetActive(false);
    }

    public void ClickOn3_4no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_3[3].SetActive(true);
        stageConfirm_3[3].SetActive(false);
    }

    public void ClickOn3_5no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_3[4].SetActive(true);
        stageConfirm_3[4].SetActive(false);
    }

    public void ClickOn3_6no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_3[5].SetActive(true);
        stageConfirm_3[5].SetActive(false);
    }
    #endregion

    #region ClickYes definition
    public void ClickOn3_1yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage3_1");
        AdmobBanner.instance.DestroyAd();
        //SceneManager.LoadScene("Loading");
    }

    public void ClickOn3_2yes()
    {
        stageTouch.instance.SpecialClickOn();
        SceneLoad.LoadScene("newStage3_2");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn3_3yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage3_3");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn3_4yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage3_4");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn3_5yes()
    {
        stageTouch.instance.SpecialClickOn();
        SceneLoad.LoadScene("newStage3_5");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn3_6yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage3_6");
        AdmobBanner.instance.DestroyAd();
    }

    #endregion
}
