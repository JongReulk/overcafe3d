using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class lobbyManager : MonoBehaviour
{
    public GameObject LobbyMenu;
    public GameObject SettingMenu;
    public GameObject StartMenu;
    public GameObject Areusure;
    public Button Continue;
    public GameObject InfiniteMode;
    public Text InfiniteModeText;
    public GameObject InfiniteOK;
    public Button InfiniteModeButton;
    private string m_text_en = "Infinite mode has been unlocked!";
    private string m_text_ge = "Der unendliche Modus wurde freigeschaltet!";
    private string m_text_kr = "무한 모드가 잠금 해제되었습니다!";




    public GameObject CafeName;
    public Text CafeName_text;
    private string cafeName_string;

    public AudioClip ClickSound;

    public GameObject[] recommendMenu;
    private int randomMenu;

    private int isTutorial;

    private AudioSource lobbySfx;
    private int isEnd;
    private int isInfinite;
    private string Language;
    private string Infinite_language;

    public GameObject EndText;
    public GameObject InfinityDifficulty;

    public GameObject AdMobBanner;

    

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<musicContinue>().PlayMusic();
        isInfinite = PlayerPrefs.GetInt("isInfinite", 0);
        Fungus.Flowchart.BroadcastFungusMessage("lobby!");

        isEnd = PlayerPrefs.GetInt("IsEnd", 0);
        
        Language = PlayerPrefs.GetString("m_language", "English");
        print(Language);

        lobbySfx = GetComponent<AudioSource>();
        
        randomMenu = Random.Range(0, recommendMenu.Length);
        for (int i = 0; i < recommendMenu.Length; i++)
        {
            recommendMenu[i].SetActive(false);
        }
        recommendMenu[randomMenu].SetActive(true);

        isTutorial = PlayerPrefs.GetInt("isTutorial", 0);
        if (isTutorial == 0)
        {
            Continue.interactable = false;
        }

        else
        {
            Continue.interactable = true;
        }

        SettingMenu.SetActive(false);
        StartMenu.SetActive(false);
        Areusure.SetActive(false);
        InfiniteMode.SetActive(false);
        InfinityDifficulty.SetActive(false);
        LobbyMenu.SetActive(true);
        EndText.SetActive(false);



        cafeName_string = PlayerPrefs.GetString("cafename","");

        
        if (cafeName_string != null)
        {
            CafeName_text.text = cafeName_string;
            CafeName.SetActive(true);
        }

        if (cafeName_string == "")
        {
            CafeName.SetActive(false);
        }

        if (isEnd == 1)
        {
            EndText.SetActive(true);
        }

        if (isInfinite == 0)
        {
            InfiniteModeButton.interactable = false;
            if (isEnd == 1)
            {
                InfiniteMode.SetActive(true);
                LobbyMenu.SetActive(false);

                PlayerPrefs.SetInt("isInfinite", 1);
                InfiniteModeButton.interactable = true;
                StartCoroutine(infinite_typing());
            }
        }

        if(isInfinite == 1)
        {
            InfiniteModeButton.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator infinite_typing()
    {
        if(Language == "Korean")
        {
            Infinite_language = m_text_kr;
        }
        if (Language == "German")
        {
            Infinite_language = m_text_ge;
        }
        if (Language == "English")
        {
            Infinite_language = m_text_en;
        }

        yield return new WaitForSeconds(2f);
        lobbySfx.Play();
        for (int i = 0; i <= Infinite_language.Length; i++)
        {
            InfiniteModeText.text = Infinite_language.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        lobbySfx.Stop();

        yield return new WaitForSeconds(1.5f);
        InfiniteOK.SetActive(true);
        
    }

    public void ClickOnSettingButton()
    {
        lobbySfx.PlayOneShot(ClickSound);
        LobbyMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void ClickOnSettingBackButton()
    {
        lobbySfx.PlayOneShot(ClickSound);
        SettingMenu.SetActive(false);
        LobbyMenu.SetActive(true);
    }

    public void ClickOnGameStartButton()
    {
        lobbySfx.PlayOneShot(ClickSound);
        LobbyMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

    public void ClickOnGameStartBackButton()
    {
        lobbySfx.PlayOneShot(ClickSound);
        StartMenu.SetActive(false);
        LobbyMenu.SetActive(true);
    }

    public void ClickOnQuit()
    {
        Application.Quit();
    }

    public void ClickOnNewGameButton()
    {
        if (isTutorial == 0)
        {
            lobbySfx.PlayOneShot(ClickSound);
            AdmobBanner.instance.DestroyAd();
            SceneLoad.LoadScene("tutorial");
        }
        else
        {
            lobbySfx.PlayOneShot(ClickSound);
            StartMenu.SetActive(false);
            Areusure.SetActive(true);
        }
    }

    public void ClickOnContinueButton()
    {
        lobbySfx.PlayOneShot(ClickSound);
        AdmobBanner.instance.DestroyAd();
        SceneManager.LoadScene("SelectStage");
    }

    public void ClickOnyesNewGame()
    {
        lobbySfx.PlayOneShot(ClickSound);
        PlayerPrefs.DeleteAll();
        AdmobBanner.instance.DestroyAd();
        SceneLoad.LoadScene("tutorial");
    }

    public void ClickOnNoback()
    {
        lobbySfx.PlayOneShot(ClickSound);
        Areusure.SetActive(false);
        StartMenu.SetActive(true);
    }

    public void ClickSoundOn()
    {
        lobbySfx.PlayOneShot(ClickSound);
    }

    public void ClickInfiniteMode()
    {
        lobbySfx.PlayOneShot(ClickSound);
        StartMenu.SetActive(false);
        InfinityDifficulty.SetActive(true);
    }

    public void ClickInfiniteOK()
    {
        lobbySfx.PlayOneShot(ClickSound);
        InfiniteMode.SetActive(false);
        LobbyMenu.SetActive(true);
    }

    public void ClickInfiniteBack()
    {
        lobbySfx.PlayOneShot(ClickSound);
        InfinityDifficulty.SetActive(false);
        StartMenu.SetActive(true);
    }

    public void ClickInfiniteNormal()
    {
        lobbySfx.PlayOneShot(ClickSound);
        AdmobBanner.instance.DestroyAd();
        SceneLoad.LoadScene("newStage_Infinite");
    }

    public void ClickInfiniteHard()
    {
        lobbySfx.PlayOneShot(ClickSound);
        AdmobBanner.instance.DestroyAd();
        SceneLoad.LoadScene("newStage_Infinite_hard");
    }

    
    
    
}
