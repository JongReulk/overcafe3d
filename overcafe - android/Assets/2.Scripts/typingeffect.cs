using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class typingeffect : MonoBehaviour
{
    public Text tx;
    public GameObject Directed;
    public Text Programmed;
    public GameObject EndingCredit;
    public GameObject BackTotitle;
    private int isEnd;
    private string m_text = "OVERCAFE 3D";
    private string m_text_name = "Andrew Kang";
    private string m_DirectedBy = "MAIN DIRECTED & PROGRAMMED BY";
    private string m_SpecialThanks = "Special Thanks";
    private string m_SpecialThanks2 = "Improbable Studios";
    private string m_SpecialThanks1 = "Puzzle Wizard";

    private AudioSource CreditAudio;
    public AudioClip ChalkSound;

    // Start is called before the first frame update
    void Start()
    {
        isEnd = PlayerPrefs.GetInt("IsEnd", 0);
        Debug.Log("IsEnd" + isEnd);
        CreditAudio = GetComponent<AudioSource>();
        StartCoroutine(_typing());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void ClickBackToMenu()
    {
        SceneManager.LoadScene("lobby");
    }
    IEnumerator _typing()
    {
        yield return new WaitForSeconds(2f);
        CreditAudio.Play();
        for(int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        CreditAudio.Stop();
        yield return new WaitForSeconds(1.5f);
        
        
        Directed.SetActive(true);
        StartCoroutine(_typing_name());
    }

    IEnumerator _typing_name()
    {
        yield return new WaitForSeconds(2f);
        tx.text = null;
        CreditAudio.Play();
        for (int i = 0; i <= m_DirectedBy.Length; i++)
        {
            Programmed.text = m_DirectedBy.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        CreditAudio.Stop();
        yield return new WaitForSeconds(1f);
        CreditAudio.Play();
        for (int i = 0; i <= m_text_name.Length; i++)
        {
            tx.text = m_text_name.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        CreditAudio.Stop();
        yield return new WaitForSeconds(1.5f);
        
        StartCoroutine(_typing_thanks());
    }

    IEnumerator _typing_thanks()
    {
        yield return new WaitForSeconds(2f);
        CreditAudio.Play();
        tx.text = null;
        for (int i = 0; i <= m_SpecialThanks.Length; i++)
        {
            Programmed.text = m_SpecialThanks.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        CreditAudio.Stop();
        yield return new WaitForSeconds(1f);
        CreditAudio.Play();

        for (int i = 0; i <= m_SpecialThanks1.Length; i++)
        {
            tx.text = m_SpecialThanks1.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        CreditAudio.Stop();

        yield return new WaitForSeconds(1.5f);

        CreditAudio.Play();

        for (int i = 0; i <= m_SpecialThanks2.Length; i++)
        {
            tx.text = m_SpecialThanks2.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        CreditAudio.Stop();
        yield return new WaitForSeconds(1.5f);

        Directed.SetActive(false);
        EndingCredit.SetActive(true);
        tx.text = null;
        Programmed.text = null;

        
        if (isEnd == 1)
        {
            BackTotitle.SetActive(true);
        }


    }
}
