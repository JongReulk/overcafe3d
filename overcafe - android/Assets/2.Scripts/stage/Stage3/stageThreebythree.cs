using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageThreebythree : MonoBehaviour
{
    public Text StageName3_3;
    public Text BestScore3_3;
    private int score;
    private bool checkScore;
    private int score_3_3;
    private int score_3_3_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName3_3.text = "3-3 stage";
        score_3_3 = PlayerPrefs.GetInt("score_3_3", 0);
        score_3_3_star = PlayerPrefs.GetInt("score_3_3_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_3_3 = PlayerPrefs.GetInt("score_3_3", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_3_3)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_3_3", bestScore);
            }
            BestScore3_3.text = score_3_3.ToString();

            if (!checkScore)
            {
                if (score > 240)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_3_3_star < 1)
                    {
                        PlayerPrefs.SetInt("score_3_3_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 280)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_3_3_star < 2)
                    {
                        PlayerPrefs.SetInt("score_3_3_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 320)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_3_3_star < 3)
                    {
                        PlayerPrefs.SetInt("score_3_3_star", 3);
                    }
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }
    }
}
