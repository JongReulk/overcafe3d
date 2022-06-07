using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLoad : MonoBehaviour
{
    

    public Slider progressbar;
    public GameObject LoadingText;
    public GameObject LoadingEndText;

    public GameObject[] randomImage;
    

    private string loadSceneName;

    public static string nextScene;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<musicContinue>().StopMusic();

        int orderRandom = Random.Range(0, 4);

        for (int i = 0; i < randomImage.Length; i++)
        {
            randomImage[i].SetActive(false);
        }

        randomImage[orderRandom].SetActive(true);

        
        LoadingText.SetActive(true);
        LoadingEndText.SetActive(false);
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
        
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            yield return null;
            if(progressbar.value<1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            else
            {
                LoadingText.SetActive(false);
                LoadingEndText.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
