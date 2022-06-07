using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageStart1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<musicContinue>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickOnBackToLobby()
    {
        //soundManager.instance.isClick = true;
        AdmobBanner.instance.DestroyAd();
        SceneManager.LoadScene("lobby");
        
    }

    
}
