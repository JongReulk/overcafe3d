using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();


            }

            return m_instance;
        }
    }

    private static GameManager m_instance;

    public bool isPassed = false;
    public bool star_1;
    public bool star_2;
    public bool star_3;

    public bool isPaused;
    private bool isResume;
    private bool isRestart;
    private bool isQuited;
    public bool isGameOver;
    public bool isOrderSuccess;
    public bool isHurryup;
    private bool isStoryContinue;

    public int maxCombo;
    public int fail_num;
    private float elapsedTime;

    private int stageNum;

    public GameObject StartPanel;
    public GameObject BackgroundPanel;
    public GameObject StoryBackButton;
    public GameObject StoryVolume;




    [Header("Score&Time")]
    public int score;
    public int tip;
    public int scoreResult;
    public int multiTip;
    public int combo;
    public Text scoreText;
    public Text MultiTipText;
    public Text TimerText;
    public Text TipText;
    public GameObject TipObject;
    public GameObject TipFire;
    public GameObject TipBlueFire;
    public GameObject TipPurpleFire;
    private float gameTime = 120f;
    //private float gameTime = 10f;



    //private float hurryUpTime = 5f;
    private float hurryUpTime = 90f;



    private float startTime;
    public GameObject StageComplete;
    public Text recordText;
    private int isTutorial;

    [Header("Pause")]
    public Button pauseButton;
    public GameObject pauseMenu;

    [Header("Star")]
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

  
    private bool isAd;



    private void Awake()
    {
        Application.targetFrameRate = 30;
    }


    // Start is called before the first frame update
    void Start()
    {
        scoreResult = 0;
        startTime = 0;
        elapsedTime = 0f;
        multiTip = 1;
        combo = 0;
        maxCombo = 0;
        fail_num = 0;
        isAd = true;
        isStoryContinue = false;
        TipFire.SetActive(false);

        AdmobBanner.instance.ToggleAd(false);
        

        stageNum = PlayerPrefs.GetInt("Stage", 0);
        isTutorial = PlayerPrefs.GetInt("isTutorial", 0);

        if (stageNum == 100)
        {
            gameTime = 300f;
            //gameTime = 10f;





            hurryUpTime = 270f;
            //hurryUpTime = 7f;




        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (!isGameOver)
        {
            if (isTutorial == 0)
            {
                scoreText.text = scoreResult.ToString();
                if (combo < 5)
                {
                    TipFire.SetActive(false);
                    TipBlueFire.SetActive(false);
                    TipPurpleFire.SetActive(false);
                    multiTip = 1;
                    MultiTipText.text = null;
                }
                if (combo > 5)
                {
                    TipFire.SetActive(true);
                    TipBlueFire.SetActive(false);
                    TipPurpleFire.SetActive(false);
                    multiTip = 2;
                    MultiTipText.text = "tip x " + multiTip.ToString();
                }
                if (combo > 15)
                {
                    TipFire.SetActive(false);
                    TipBlueFire.SetActive(true);
                    TipPurpleFire.SetActive(false);
                    multiTip = 3;
                    MultiTipText.text = "tip x " + multiTip.ToString();
                }
                if (combo > 25)
                {
                    TipFire.SetActive(false);
                    TipBlueFire.SetActive(false);
                    TipPurpleFire.SetActive(true);
                    multiTip = 4;
                    MultiTipText.text = "tip x " + multiTip.ToString();
                }

                if (isOrderSuccess)
                {
                    //scoreResult = score + tip;
                    StartCoroutine(SetTip());
                    //scoreText.text = scoreResult.ToString();
                    isOrderSuccess = false;
                }
                return;
            }

            if (!isPaused)
            {
                pauseButton.interactable = true;
            }
            if (isPaused)
            {
                pauseButton.interactable = false;
                return;
            }
            CountdownTimer();
            scoreText.text = scoreResult.ToString();
            if (combo < 5)
            {
                TipFire.SetActive(false);
                TipBlueFire.SetActive(false);
                TipPurpleFire.SetActive(false);
                multiTip = 1;
                MultiTipText.text = null;
            }
            if (combo > 5)
            {
                TipFire.SetActive(true);
                TipBlueFire.SetActive(false);
                TipPurpleFire.SetActive(false);
                multiTip = 2;
                MultiTipText.text = "tip x " + multiTip.ToString();
            }
            if (combo > 15)
            {
                TipFire.SetActive(false);
                TipBlueFire.SetActive(true);
                TipPurpleFire.SetActive(false);
                multiTip = 3;
                MultiTipText.text = "tip x " + multiTip.ToString();
            }
            if (combo > 25)
            {
                TipFire.SetActive(false);
                TipBlueFire.SetActive(false);
                TipPurpleFire.SetActive(true);
                multiTip = 4;
                MultiTipText.text = "tip x " + multiTip.ToString();
            }
            
            if (isOrderSuccess)
            {
                //scoreResult = score + tip;
                StartCoroutine(SetTip());
                //scoreText.text = scoreResult.ToString();
                isOrderSuccess = false;
            }
            
        }
        

        if(isGameOver)
        {
            if (!isStoryContinue)
            {
                isPaused = true;

                SetAdOn();
                
                StageComplete.SetActive(true);
                soundManager.instance.isOver = true;
                recordText.text = scoreResult.ToString();

                if (star_1)
                {
                    Invoke("SetStar1", 1f);
                    star_1 = false;
                }

                if (star_2)
                {
                    Invoke("SetStar1", 1f);
                    Invoke("SetStar2", 2f);
                    star_2 = false;
                }

                if (star_3)
                {
                    Invoke("SetStar1", 1f);
                    Invoke("SetStar2", 2f);
                    Invoke("SetStar3", 3f);
                    star_3 = false;
                }
            }

            //StartCoroutine(CheckStarNum());
        }
        
    }

    public void ClickOnPauseButton()
    {
        isPaused = true;
        pauseButton.interactable = false;
        pauseMenu.SetActive(true);
        soundManager.instance.isClick = true;

        //SetAllCollidersStatus(false);
        Time.timeScale = 0.0f;
    }

    public void m_pause()
    {
        isPaused = true;
        pauseButton.interactable = false;
        
    }

    public void ClickOnResume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        soundManager.instance.isClick = true;
        Time.timeScale = 1.0f;
        pauseButton.interactable = true;
    }

    public void m_Resume()
    {
        isPaused = false;
        

        pauseButton.interactable = true;
        
    }

    public void ClickOnRestart()
    {
        soundManager.instance.isClick = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPaused = false;
        Time.timeScale = 1.0f;
        isRestart = false;
    }

    public void ClickOnQuit()
    {
        //isQuited
        soundManager.instance.isClick = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SelectStage");
    }

    public void ClickCompleteBack()
    {
        soundManager.instance.isClick = true;
        SceneManager.LoadScene("SelectStage");
    }

    public void ClickCompleteBackLobby()
    {
        soundManager.instance.isClick = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("lobby");
    }

    IEnumerator SetTip()
    {
        TipText.text = "+ " + tip.ToString();
        TipObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        TipObject.SetActive(false);
    }

    public void SetAllCollidersStatus(bool active)
    {
        // 모든 콜라이더 활성/비활성화
        foreach(Collider AllCollider in GetComponentsInChildren<Collider>())
        {
            AllCollider.enabled = active;
            //print(active);
        }
    }

    void SetStar1()
    {
        Star1.SetActive(true);
        soundManager.instance.isStar_1 = true;
    }

    void SetStar2()
    {
        Star2.SetActive(true);
        soundManager.instance.isStar_2 = true;
        
    }

    void SetStar3()
    {
        Star3.SetActive(true);
        soundManager.instance.isStar_3 = true;
    }

    

    void CountdownTimer()
    {
        if(stageNum == 200 || stageNum == 250)
        {
            return;
        }
        //float elapsedTime = Time.time - startTime;
        elapsedTime += Time.deltaTime;

        int minutes = (int)((gameTime - elapsedTime) / 60) % 60;
        
        int seconds = (int)((gameTime - elapsedTime) % 60);

        TimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (elapsedTime >= hurryUpTime)
        {
            isHurryup = true;
            TimerText.color = Color.red;
        }
        if (elapsedTime >= gameTime)
        {
            
            isGameOver = true;
            isHurryup = false;
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        PlayerPrefs.SetInt("isTutorial", 1);
    }

    public void StartPanelActive()
    {
        BackgroundPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void StoryContinue()
    {
        isStoryContinue = true;
        StageComplete.SetActive(false);
        BackgroundPanel.SetActive(true);
        StoryVolume.SetActive(true);
    }

    public void SetStoryBackButton()
    {
        StoryBackButton.SetActive(true);
    }

    public void SetStoryVolumeFalse()
    {
        StoryVolume.SetActive(false);
    }

    public void SetAdOn()
    {
        if (isAd)
        {
            int orderRandom = Random.Range(0, 3);
            if (orderRandom == 0)
            {
                AdmobBanner.instance.ToggleAd(true);
            }
            else
            {
                AdmobScreen.instance.Show();
                AdmobBanner.instance.ToggleAd(false);
            }

            isAd = false;
        }
    }
}
