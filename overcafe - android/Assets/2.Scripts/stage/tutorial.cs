using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Text StageName;
    public Text BestScore;
    private int score;
    private bool checkScore;
    private int score_1_1;
    private int score_1_1_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        StageName.text = "Tutorial";
        

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;

        if (GameManager.instance.isGameOver)
        {
            BestScore.text = null;
            if (!checkScore)
            {
                GameManager.instance.star_1 = false;
                GameManager.instance.star_2 = false;
                GameManager.instance.star_3 = true;

                print("stage one 3 star");


                checkScore = true;
            }
        }
            

        

    }
}
