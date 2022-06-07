using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stagefourbyfive : MonoBehaviour
{
    public Text StageName4_5;
    public Text BestScore4_5;
    private int score;
    private bool checkScore;
    private int score_4_5;
    private int score_4_5_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName4_5.text = "4-5 stage";
        score_4_5 = PlayerPrefs.GetInt("score_4_5", 0);
        score_4_5_star = PlayerPrefs.GetInt("score_4_5_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_4_5 = PlayerPrefs.GetInt("score_4_5", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_4_5)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_4_5", bestScore);
            }
            BestScore4_5.text = score_4_5.ToString();

            if (!checkScore)
            {
                if (score > 320)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_4_5_star < 1)
                    {
                        PlayerPrefs.SetInt("score_4_5_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 360)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_4_5_star < 2)
                    {
                        PlayerPrefs.SetInt("score_4_5_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 400)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_4_5_star < 3)
                    {
                        PlayerPrefs.SetInt("score_4_5_star", 3);
                    }
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }
    }
}
