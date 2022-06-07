using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [Header("BackgroundMusic")]
    public Text MusicVolumeText;
    public Slider MusicVolumeSlider;
    private float musicVolume;

    
    [Header("SoundEffect")]

    public Text SoundEffectVolumeText;
    public Slider SoundEffectVolumeSlider;
    private float soundEffectVolume;

    // Start is called before the first frame update
    void Start()
    {
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 5f);
        SoundEffectVolumeSlider.value = PlayerPrefs.GetFloat("soundEffect", 5f);

    }

    // Update is called once per frame
    void Update()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 5f);
        soundEffectVolume = PlayerPrefs.GetFloat("soundEffect", 5f);
        
        SetMusicVolumeText();
        SetSoundEffectVolumeText();
    }

    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", MusicVolumeSlider.value);
        
        //musicVolume = vol;
    }

    public void SetEffectVolume()
    {
        PlayerPrefs.SetFloat("soundEffect", SoundEffectVolumeSlider.value);
        
    }



    void SetMusicVolumeText()
    {

        MusicVolumeText.text = (int)(musicVolume * 10) + "%";
        

    }

    void SetSoundEffectVolumeText()
    {
        SoundEffectVolumeText.text = (int)(soundEffectVolume * 10) + "%";
        
    }
}
