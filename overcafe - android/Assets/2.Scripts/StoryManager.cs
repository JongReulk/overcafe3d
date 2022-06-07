using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private int isAnnie;
    // Start is called before the first frame update
    void Start()
    {
        isAnnie = PlayerPrefs.GetInt("IsAnnie", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ani_yes()
    {
        PlayerPrefs.SetInt("IsAnnie", 1);
        isAnnie = PlayerPrefs.GetInt("IsAnnie");
        Debug.Log("IsAnnie"+isAnnie);
    }

    public void Ani_no()
    {
        PlayerPrefs.SetInt("IsAnnie", 0);
        isAnnie = PlayerPrefs.GetInt("IsAnnie");
        Debug.Log("IsAnnie" + isAnnie);
    }

    public void Trevor_yes()
    {
        PlayerPrefs.SetInt("IsTrevor", 1);
        
    }

    public void Trevor_no()
    {
        PlayerPrefs.SetInt("IsTrevor", 0);
    }

    public void Sherlock_yes()
    {
        PlayerPrefs.SetInt("IsSherlock", 0);
    }

    public void Sherlock_no()
    {
        PlayerPrefs.SetInt("IsSherlock", 0);
    }
}
