using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurryup : MonoBehaviour
{
    private AudioSource HurryUp;
    // Start is called before the first frame update
    void Start()
    {
        HurryUp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckPaused());
    }

    IEnumerator CheckPaused()
    {
        if(GameManager.instance.isPaused)
        {
            HurryUp.Pause();
        }

        else
        {
            HurryUp.UnPause();
        }
               
        yield return null;
    }
}
