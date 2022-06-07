using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class stageThreebyone : MonoBehaviour
{
    public Text StageName3_1;
    public Text BestScore3_1;
    private int score;
    private bool checkScore;
    private int score_3_1;
    private int score_3_1_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName3_1.text = "3-1 stage";
        score_3_1 = PlayerPrefs.GetInt("score_3_1", 0);
        score_3_1_star = PlayerPrefs.GetInt("score_3_1_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_3_1 = PlayerPrefs.GetInt("score_3_1", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_3_1)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_3_1", bestScore);
            }
            BestScore3_1.text = score_3_1.ToString();

            if (!checkScore)
            {
                if (score > 280)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_3_1_star < 1)
                    {
                        PlayerPrefs.SetInt("score_3_1_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 320)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_3_1_star < 2)
                    {
                        PlayerPrefs.SetInt("score_3_1_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 360)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_3_1_star < 3)
                    {
                        PlayerPrefs.SetInt("score_3_1_star", 3);
                    }
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }
    }
}
