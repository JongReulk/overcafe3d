using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class startTyping : MonoBehaviour
{
    public Text OvercafeText;
    public Text OpenText;
    public Text Touch2startText;
    private AudioSource startAudio;
    public GameObject ClickPanel;
    public GameObject LobbyMenu;
    public GameObject NonComplete;
    public GameObject Complete;

    public Camera StartCamera;
    public Camera LobbyCamera;
    private string Language;
    private string overcafe_language;
    private string open_language;
    private string Touch2start_language;
    private string overcafe_text_en = "OVERCAFE 3D";
    private string overcafe_text_kr = "오버카페 3D";

    private string open_text_en = "Open";
    private string open_text_ge = "öffnen";
    private string open_text_kr = "오픈";

    private string Touch2start_en = "Touch to start";
    private string Touch2start_ge = "Berühren Sie, um zu starten";
    private string Touch2start_kr = "터치하여 시작하세요";

    private bool isClick;
    

   

    private void Awake()
    {

    }



    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<musicContinue>().PlayMusic();
        startAudio = GetComponent<AudioSource>();
        Language = PlayerPrefs.GetString("m_language", "English");
        
        isClick = false;
        StartCoroutine(overcafe_typing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    




    IEnumerator overcafe_typing()
    {
        


        if (Language == "Korean")
        {
            overcafe_language = overcafe_text_kr;
            open_language = open_text_kr;
            Touch2start_language = Touch2start_kr;
        }
        if (Language == "German")
        {
            overcafe_language = overcafe_text_en;
            open_language = open_text_ge;
            Touch2start_language = Touch2start_ge;
        }
        if (Language == "English")
        {
            overcafe_language = overcafe_text_en;
            open_language = open_text_en;
            Touch2start_language = Touch2start_en;
        }

        yield return new WaitForSeconds(1f);
        startAudio.Play();
        
        for (int i = 0; i <= overcafe_language.Length; i++)
        {
            
            OvercafeText.text = overcafe_language.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        startAudio.Stop();

        yield return new WaitForSeconds(1f);

        ClickPanel.SetActive(true);

        startAudio.Play();
        for (int i = 0; i <= open_language.Length; i++)
        {
            OpenText.text = open_language.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        startAudio.Stop();

        yield return new WaitForSeconds(1f);

        startAudio.Play();
        for (int i = 0; i <= Touch2start_language.Length; i++)
        {
            Touch2startText.text = Touch2start_language.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        startAudio.Stop();

        yield return new WaitForSeconds(1f);
        NonComplete.SetActive(false);
        Complete.SetActive(true);

        isClick = true;

        


    }

    public void TouchStartScreen()
    {
        

        if (isClick)
        {
            startAudio.clip = null;
            SceneManager.LoadScene("lobby");
        }

        if (!isClick)
        {
            startAudio.clip = null;
            NonComplete.SetActive(false);
            Complete.SetActive(true);
            isClick = true;
        }
        
    }

    public void InternetConfirm()
    {
        Application.Quit();
    }

    
}
