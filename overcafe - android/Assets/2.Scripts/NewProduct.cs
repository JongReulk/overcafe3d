using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProduct : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject backgroundPanel;
    public GameObject StoryVolume;
    public GameObject ProductPanel;
    public GameObject CharacterPanel;
    

    private void Awake()
    {
        GameManager.instance.isPaused = true;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator introduceNew()
    {
        GameManager.instance.isPaused = true;
        yield return null;
        
    }

    public void NewClick_cupcakeset()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("cupcakeset!!");
    }

    public void NewClick_camera()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("camera!!");
    }

    public void NewClick_cover()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("cover!!");
    }

    public void NewClick_threeset()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("threeset!!");
    }

    public void NewClick_Final()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("Final!!");
    }

    public void NewClick_Infinite()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("Infinite!!");
    }

    public void NewClick_InfiniteH()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("InfiniteH!!");
    }

    public void NewClick_default()
    {
        StartPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void NewClick_Character_pop()
    {
        ProductPanel.SetActive(false);
        CharacterPanel.SetActive(true);
    }

    public void NewClick_AniFirst()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("AniFirst!");
        StoryVolume.SetActive(true);
    }

    public void NewClick_AniSecond()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("AniSecond!");
        StoryVolume.SetActive(true);
    }


    public void Story_TrevorFirst()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("TrevorFirst!");
        StoryVolume.SetActive(true);
    }

    public void Story_TrevorSecond()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("TrevorSecond!");
        StoryVolume.SetActive(true);
    }

    public void Story_ShelockFirst()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("ShelockFirst!");
        StoryVolume.SetActive(true);
    }

    public void Story_ShelockSecond()
    {
        gameObject.SetActive(false);
        backgroundPanel.SetActive(true);
        Fungus.Flowchart.BroadcastFungusMessage("ShelockSecond!");
        StoryVolume.SetActive(true);
    }






}
