using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stage1_select : MonoBehaviour
{
    private int stage1_1_score;
    private int stage1_2_score;
    private int stage1_3_score;
    private int stage1_4_score;
    private int stage1_5_score;
    private int stage1_6_score;

    private int score1_1_star;
    private int score1_2_star;
    private int score1_3_star;
    private int score1_4_star;
    private int score1_5_star;
    private int score1_6_star;


    private int stage1_levelat;
    private int stage2_levelat;

    [Header("Star")]
    public GameObject[] stage1_1_star;
    public GameObject[] stage1_2_star;
    public GameObject[] stage1_3_star;
    public GameObject[] stage1_4_star;
    public GameObject[] stage1_5_star;
    public GameObject[] stage1_6_star;

    [Header("Stage Idle")]
    public GameObject[] stageIdle;

    [Header("Stage Confirm")]
    public GameObject[] stageConfirm;

    [Header("Stage Lock")]
    public GameObject[] stageLock;
    // [0] -> stage, [1] -> confirm, [3] -> lock

    //public Button[] Clearstage;


    // Start is called before the first frame update
    void Start()
    {
        score1_1_star = PlayerPrefs.GetInt("score_1_1_star", 0);
        score1_2_star = PlayerPrefs.GetInt("score_1_2_star", 0);
        score1_3_star = PlayerPrefs.GetInt("score_1_3_star", 0);
        score1_4_star = PlayerPrefs.GetInt("score_1_4_star", 0);
        score1_5_star = PlayerPrefs.GetInt("score_1_5_star", 0);
        score1_6_star = PlayerPrefs.GetInt("score_1_6_star", 0);

        stage1_levelat = PlayerPrefs.GetInt("stage1_levelat", 1);
        stage2_levelat = PlayerPrefs.GetInt("stage2_levelat", 0);



        #region stage1_levelat
        if (stage1_levelat < 2)
        {
            if(score1_1_star > 0)
            {
                PlayerPrefs.SetInt("stage1_levelat", 2);
            }
        }

        if (stage1_levelat < 3)
        {
            if (score1_2_star > 0)
            {
                PlayerPrefs.SetInt("stage1_levelat", 3);
            }
        }

        if (stage1_levelat < 4)
        {
            if (score1_3_star > 0)
            {
                PlayerPrefs.SetInt("stage1_levelat", 4);
            }
        }

        if (stage1_levelat < 5)
        {
            if (score1_4_star > 0)
            {
                PlayerPrefs.SetInt("stage1_levelat", 5);
            }
        }

        if (stage1_levelat < 6)
        {
            if (score1_5_star > 0)
            {
                PlayerPrefs.SetInt("stage1_levelat", 6);
            }
        }
        
        if (stage1_levelat < 7)
        {
            if (score1_6_star > 0)
            {
                PlayerPrefs.SetInt("stage1_levelat", 6);
                if (stage2_levelat == 0)
                {
                    PlayerPrefs.SetInt("stage2_levelat", 1);
                }
            }
        }
        #endregion

        stage1_levelat = PlayerPrefs.GetInt("stage1_levelat", 1);
        Debug.Log("Stage1_level at " + stage1_levelat);

        for (int i = 0; i < stageIdle.Length; i++)
        {
            stageIdle[i].SetActive(false);
            stageConfirm[i].SetActive(false);
            stageLock[i].SetActive(true);
        }

        /*
        for (int i = 0; i < stage1_levelat; i++)
        {
            stageLock[i].SetActive(false);
            stageIdle[i].SetActive(true);
        }
        */

        for (int i = 0; i < stage1_levelat; i++)
        {
            stageLock[i].SetActive(false);
            stageIdle[i].SetActive(true);
        }


        #region star
        for (int i = 0; i < score1_1_star; i++)
        {
            stage1_1_star[i].SetActive(true);
        }

        for (int i = 0; i < score1_2_star; i++)
        {
            stage1_2_star[i].SetActive(true);
        }

        for (int i = 0; i < score1_3_star; i++)
        {
            stage1_3_star[i].SetActive(true);
        }

        for (int i = 0; i < score1_4_star; i++)
        {
            stage1_4_star[i].SetActive(true);
        }

        for (int i = 0; i < score1_5_star; i++)
        {
            stage1_5_star[i].SetActive(true);
        }

        for (int i = 0; i < score1_6_star; i++)
        {
            stage1_6_star[i].SetActive(true);
        }

        #endregion

    }

    #region ClickImage definition
    public void ClickOn1_1Image()
    {
        
        stageIdle[0].SetActive(false);
        stageConfirm[0].SetActive(true);
        stageTouch.instance.StageSoundOn();
    }

    public void ClickOn1_2Image()
    {
        stageIdle[1].SetActive(false);
        stageConfirm[1].SetActive(true);
        stageTouch.instance.StageSoundOn();
    }

    public void ClickOn1_3Image()
    {
        stageIdle[2].SetActive(false);
        stageConfirm[2].SetActive(true);
        stageTouch.instance.StageSoundOn();
    }

    public void ClickOn1_4Image()
    {
        stageIdle[3].SetActive(false);
        stageConfirm[3].SetActive(true);
        stageTouch.instance.StageSoundOn();
    }

    public void ClickOn1_5Image()
    {
        stageIdle[4].SetActive(false);
        stageConfirm[4].SetActive(true);
        stageTouch.instance.StageSoundOn();
    }

    public void ClickOn1_6Image()
    {
        stageIdle[5].SetActive(false);
        stageConfirm[5].SetActive(true);
        stageTouch.instance.StageSoundOn();
    }
    #endregion

    #region ClickNo definition
    public void ClickOn1_1no()
    {
        
        stageIdle[0].SetActive(true);
        stageConfirm[0].SetActive(false);
        stageTouch.instance.StageSelectOn();
    }

    public void ClickOn1_2no()
    {
        stageIdle[1].SetActive(true);
        stageConfirm[1].SetActive(false);
        stageTouch.instance.StageSelectOn();
    }

    public void ClickOn1_3no()
    {
        stageIdle[2].SetActive(true);
        stageConfirm[2].SetActive(false);
        stageTouch.instance.StageSelectOn();
    }

    public void ClickOn1_4no()
    {
        stageIdle[3].SetActive(true);
        stageConfirm[3].SetActive(false);
        stageTouch.instance.StageSelectOn();
    }

    public void ClickOn1_5no()
    {
        stageIdle[4].SetActive(true);
        stageConfirm[4].SetActive(false);
        stageTouch.instance.StageSelectOn();
    }

    public void ClickOn1_6no()
    {
        stageIdle[5].SetActive(true);
        stageConfirm[5].SetActive(false);
        stageTouch.instance.StageSelectOn();
    }
    #endregion

    #region ClickYes definition
    public void ClickOn1_1yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage1_1");
        AdmobBanner.instance.DestroyAd();
        //SceneManager.LoadScene("Loading");
    }

    public void ClickOn1_2yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage1_2");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn1_3yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage1_3");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn1_4yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage1_4");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn1_5yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage1_5");
        AdmobBanner.instance.DestroyAd();
    }

    public void ClickOn1_6yes()
    {
        stageTouch.instance.StageSoundOn();
        SceneLoad.LoadScene("newStage1_6");
        AdmobBanner.instance.DestroyAd();
    }

    #endregion
}

