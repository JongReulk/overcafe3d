using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class TutorialStart : MonoBehaviour
{

    public GameObject[] TutorialStage;

    public GameObject cafeImage;
    private int isTutorial;
    private int isLanguage;

    public Flowchart flowchart;
    private string cafename;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("isTutorial", 0);
        isTutorial = PlayerPrefs.GetInt("isTutorial", 0);
        cafeImage.SetActive(true);
        for (int i = 0; i < TutorialStage.Length; i++)
            TutorialStage[i].SetActive(false);

        isLanguage = PlayerPrefs.GetInt("isLanguage", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTutorial()
    {
        cafeImage.SetActive(false);
        for(int i = 0; i<TutorialStage.Length; i++)
            TutorialStage[i].SetActive(true);

        GameManager.instance.isPaused = true;
        Fungus.Flowchart.BroadcastFungusMessage("Start!");
        Debug.Log("Start!");
    }

    public void GoToStageSelect()
    {
        SceneManager.LoadScene("SelectStage");
    }

    public void SetKorean()
    {
        PlayerPrefs.SetString("m_language", "Korean");
        print("KO");
        
    }

    public void SetEnglish()
    {
        PlayerPrefs.SetString("m_language", "English");
        print("EN");

    }

    public void SetGerman()
    {
        PlayerPrefs.SetString("m_language", "German");
        print("GER");

    }

    public void InputCafeName()
    {
        cafename = flowchart.GetStringVariable("cafename");
        Debug.Log("cafename " + cafename);
        PlayerPrefs.SetString("cafename", cafename);
    }
}
