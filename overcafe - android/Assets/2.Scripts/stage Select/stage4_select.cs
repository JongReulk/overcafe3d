using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4_select : MonoBehaviour
{
    private int stage4_1_score;
    private int stage4_2_score;
    private int stage4_3_score;
    private int stage4_4_score;
    private int stage4_5_score;
    private int stage4_6_score;

    private int score4_1_star;
    private int score4_2_star;
    private int score4_3_star;
    private int score4_4_star;
    private int score4_5_star;
    private int score4_6_star;


    private int stage4_levelat;
    private int stage100_levelat;

    [Header("Star")]
    public GameObject[] stage4_1_star;
    public GameObject[] stage4_2_star;
    public GameObject[] stage4_3_star;
    public GameObject[] stage4_4_star;
    public GameObject[] stage4_5_star;
    public GameObject[] stage4_6_star;

    [Header("Stage Idle")]
    public GameObject[] stageIdle_4;

    [Header("Stage Confirm")]
    public GameObject[] stageConfirm_4;

    [Header("Stage Lock")]
    public GameObject[] stageLock_4;
    // [0] -> stage, [1] -> confirm, [3] -> lock

    //public Button[] Clearstage;


    // Start is called before the first frame update
    void Start()
    {
        score4_1_star = PlayerPrefs.GetInt("score_4_1_star", 0);
        score4_2_star = PlayerPrefs.GetInt("score_4_2_star", 0);
        score4_3_star = PlayerPrefs.GetInt("score_4_3_star", 0);
        score4_4_star = PlayerPrefs.GetInt("score_4_4_star", 0);
        score4_5_star = PlayerPrefs.GetInt("score_4_5_star", 0);
        score4_6_star = PlayerPrefs.GetInt("score_4_6_star", 0);

        stage4_levelat = PlayerPrefs.GetInt("stage4_levelat", 0);
        stage100_levelat = PlayerPrefs.GetInt("stage100_levelat", 0);



        #region stage4_levelat
        if (stage4_levelat < 2)
        {
            if (score4_1_star > 0)
            {
                PlayerPrefs.SetInt("stage4_levelat", 2);
            }
        }

        if (stage4_levelat < 3)
        {
            if (score4_2_star > 0)
            {
                PlayerPrefs.SetInt("stage4_levelat", 3);
            }
        }

        if (stage4_levelat < 4)
        {
            if (score4_3_star > 0)
            {
                PlayerPrefs.SetInt("stage4_levelat", 4);
            }
        }

        if (stage4_levelat < 5)
        {
            if (score4_4_star > 0)
            {
                PlayerPrefs.SetInt("stage4_levelat", 5);
            }
        }

        if (stage4_levelat < 6)
        {
            if (score4_5_star > 0)
            {
                PlayerPrefs.SetInt("stage4_levelat", 6);
            }
        }

        if (stage4_levelat < 7)
        {
            if (score4_6_star > 0)
            {
                PlayerPrefs.SetInt("stage4_levelat", 6);
                if (stage100_levelat == 0)
                {
                    PlayerPrefs.SetInt("stage100_levelat", 1);
                }
            }
        }
        #endregion

        stage4_levelat = PlayerPrefs.GetInt("stage4_levelat", 0);
        stage100_levelat = PlayerPrefs.GetInt("stage100_levelat");
        Debug.Log("Stage4_level at " + stage4_levelat);


        for (int i = 0; i < stageIdle_4.Length; i++)
        {
            stageIdle_4[i].SetActive(false);
            stageConfirm_4[i].SetActive(false);
            stageLock_4[i].SetActive(true);
        }

        /*
        for (int i = 0; i < stage1_levelat; i++)
        {
            stageLock[i].SetActive(false);
            stageIdle[i].SetActive(true);
        }
        */

        for (int i = 0; i < stage4_levelat; i++)
        {
            stageLock_4[i].SetActive(false);
            stageIdle_4[i].SetActive(true);
        }


        #region star
        for (int i = 0; i < score4_1_star; i++)
        {
            stage4_1_star[i].SetActive(true);
        }

        for (int i = 0; i < score4_2_star; i++)
        {
            stage4_2_star[i].SetActive(true);
        }

        for (int i = 0; i < score4_3_star; i++)
        {
            stage4_3_star[i].SetActive(true);
        }

        for (int i = 0; i < score4_4_star; i++)
        {
            stage4_4_star[i].SetActive(true);
        }

        for (int i = 0; i < score4_5_star; i++)
        {
            stage4_5_star[i].SetActive(true);
        }

        for (int i = 0; i < score4_6_star; i++)
        {
            stage4_6_star[i].SetActive(true);
        }

        #endregion

    }

    #region ClickImage definition
    public void ClickOn4_1Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_4[0].SetActive(false);
        stageConfirm_4[0].SetActive(true);
    }

    public void ClickOn4_2Image()
    {
        stageTouch.instance.SpecialClickOn();
        stageIdle_4[1].SetActive(false);
        stageConfirm_4[1].SetActive(true);
    }

    public void ClickOn4_3Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_4[2].SetActive(false);
        stageConfirm_4[2].SetActive(true);
    }

    public void ClickOn4_4Image()
    {
        stageTouch.instance.SpecialClickOn();
        stageIdle_4[3].SetActive(false);
        stageConfirm_4[3].SetActive(true);
    }

    public void ClickOn4_5Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_4[4].SetActive(false);
        stageConfirm_4[4].SetActive(true);
    }

    public void ClickOn4_6Image()
    {
        stageTouch.instance.StageSoundOn();
        stageIdle_4[5].SetActive(false);
        stageConfirm_4[5].SetActive(true);
    }
    #endregion

    #region ClickNo definition
    public void ClickOn4_1no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_4[0].SetActive(true);
        stageConfirm_4[0].SetActive(false);
    }

    public void ClickOn4_2no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_4[1].SetActive(true);
        stageConfirm_4[1].SetActive(false);
    }

    public void ClickOn4_3no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_4[2].SetActive(true);
        stageConfirm_4[2].SetActive(false);
    }

    public void ClickOn4_4no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_4[3].SetActive(true);
        stageConfirm_4[3].SetActive(false);
    }

    public void ClickOn4_5no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_4[4].SetActive(true);
        stageConfirm_4[4].SetActive(false);
    }

    public void ClickOn4_6no()
    {
        stageTouch.instance.StageSelectOn();
        stageIdle_4[5].SetActive(true);
        stageConfirm_4[5].SetActive(false);
    }
    #endregion

    #region ClickYes definition
    public void ClickOn4_1yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage4_1");
        AdmobBanner.instance.DestroyAd();
        //SceneManager.LoadScene("Loading");
    }

    public void ClickOn4_2yes()
    {
        stageTouch.instance.SpecialClickOn();
        SceneLoad.LoadScene("newStage4_2");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn4_3yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage4_3");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn4_4yes()
    {
        stageTouch.instance.SpecialClickOn();
        SceneLoad.LoadScene("newStage4_4");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn4_5yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage4_5");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn4_6yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage_final");
        AdmobBanner.instance.DestroyAd();
    }

    #endregion
}
