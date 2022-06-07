using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxvolume : MonoBehaviour
{
    private AudioSource sfxMusic;
    private float sfxVolume;


    // Start is called before the first frame update
    void Start()
    {

        sfxMusic = GetComponent<AudioSource>();
        sfxVolume = PlayerPrefs.GetFloat("soundEffect", 5f);
        sfxMusic.volume = sfxVolume / 10;
        Debug.Log("Volume : " + sfxMusic.volume);



    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SetSfxVolume());
    }

    IEnumerator SetSfxVolume()
    {
        sfxVolume = PlayerPrefs.GetFloat("soundEffect", 5f);
        sfxMusic.volume = sfxVolume / 10;
        yield return null;
    }
}
