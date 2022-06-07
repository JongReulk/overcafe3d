using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stagefourbyone : MonoBehaviour
{
    public Text StageName4_1;
    public Text BestScore4_1;
    private int score;
    private bool checkScore;
    private int score_4_1;
    private int score_4_1_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName4_1.text = "4-1 stage";
        score_4_1 = PlayerPrefs.GetInt("score_4_1", 0);
        score_4_1_star = PlayerPrefs.GetInt("score_4_1_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_4_1 = PlayerPrefs.GetInt("score_4_1", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_4_1)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_4_1", bestScore);
            }
            BestScore4_1.text = score_4_1.ToString();

            if (!checkScore)
            {
                if (score > 280)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_4_1_star < 1)
                    {
                        PlayerPrefs.SetInt("score_4_1_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 320)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_4_1_star < 2)
                    {
                        PlayerPrefs.SetInt("score_4_1_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 360)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_4_1_star < 3)
                    {
                        PlayerPrefs.SetInt("score_4_1_star", 3);
                    }
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }
    }
}
