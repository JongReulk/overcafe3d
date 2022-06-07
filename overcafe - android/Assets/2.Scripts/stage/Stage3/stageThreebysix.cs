using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageThreebysix : MonoBehaviour
{
    public Text StageName3_6;
    public Text BestScore3_6;
    private int score;
    private bool checkScore;
    private int score_3_6;
    private int score_3_6_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName3_6.text = "3-6 stage";
        score_3_6 = PlayerPrefs.GetInt("score_3_6", 0);
        score_3_6_star = PlayerPrefs.GetInt("score_3_6_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_3_6 = PlayerPrefs.GetInt("score_3_6", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_3_6)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_3_6", bestScore);
            }
            BestScore3_6.text = score_3_6.ToString();

            if (!checkScore)
            {
                if (score > 220)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_3_6_star < 1)
                    {
                        PlayerPrefs.SetInt("score_3_6_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 260)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_3_6_star < 2)
                    {
                        PlayerPrefs.SetInt("score_3_6_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 390)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_3_6_star < 3)
                    {
                        PlayerPrefs.SetInt("score_3_6_star", 3);
                    }
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }
    }
}
