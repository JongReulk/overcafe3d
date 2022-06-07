using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageOnebythree : MonoBehaviour
{
    public Text StageName1_3;
    public Text BestScore1_3;
    private int score;
    private bool checkScore;
    private int score_1_3;
    private int score_1_3_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName1_3.text = "1-3 stage";
        score_1_3 = PlayerPrefs.GetInt("score_1_3", 0);
        score_1_3_star = PlayerPrefs.GetInt("score_1_3_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_1_3 = PlayerPrefs.GetInt("score_1_3", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_1_3)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_1_3", bestScore);
            }
            BestScore1_3.text = score_1_3.ToString();

            if (!checkScore)
            {
                if (score > 440)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_1_3_star < 1)
                    {
                        PlayerPrefs.SetInt("score_1_3_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 480)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_1_3_star < 2)
                    {
                        PlayerPrefs.SetInt("score_1_3_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 520)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_1_3_star < 3)
                    {
                        PlayerPrefs.SetInt("score_1_3_star", 3);
                    }
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }

    }
}
