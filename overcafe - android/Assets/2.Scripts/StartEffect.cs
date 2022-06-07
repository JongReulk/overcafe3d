using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEffect : MonoBehaviour
{
    public Image StartImage;
    public Text StartText;
    public GameObject TextGameObject;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.isPaused = true;
        
        StartCoroutine(ChangeText());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeText()
    {
        yield return new WaitForSeconds(1f);
        TextGameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartText.text = "2";
        yield return new WaitForSeconds(1f);
        StartText.text = "1";
        yield return new WaitForSeconds(1f);

        GameManager.instance.isPaused = false;
        gameObject.SetActive(false);
    }
}
