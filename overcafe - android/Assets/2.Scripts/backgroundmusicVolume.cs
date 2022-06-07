using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmusicVolume : MonoBehaviour
{
    private AudioSource backgroundMusic;
    private float musicVolume;

    
    // Start is called before the first frame update
    void Start()
    {
        
        backgroundMusic = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 5f);
        backgroundMusic.volume = musicVolume / 10;
        Debug.Log("Volume : " + backgroundMusic.volume);

        

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SetMusicVolume());
    }

    IEnumerator SetMusicVolume()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 5f);
        backgroundMusic.volume = musicVolume / 10;
        yield return null;
    }

    
}
