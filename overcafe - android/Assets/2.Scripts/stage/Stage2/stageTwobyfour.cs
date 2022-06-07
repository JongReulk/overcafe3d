using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageTwobyfour : MonoBehaviour
{
    public Text StageName2_4;
    public Text BestScore2_4;
    private int score;
    private bool checkScore;
    private int score_2_4;
    private int score_2_4_star;
    private int bestScore;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName2_4.text = "2-4 stage";
        score_2_4 = PlayerPrefs.GetInt("score_2_4", 0);
        score_2_4_star = PlayerPrefs.GetInt("score_2_4_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_2_4 = PlayerPrefs.GetInt("score_2_4", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_2_4)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_2_4", bestScore);
            }
            BestScore2_4.text = score_2_4.ToString();

            if (!checkScore)
            {
                if (score > 480)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_2_4_star < 1)
                    {
                        PlayerPrefs.SetInt("score_2_4_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 520)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_2_4_star < 2)
                    {
                        PlayerPrefs.SetInt("score_2_4_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 560)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_2_4_star < 3)
                    {
                        PlayerPrefs.SetInt("score_2_4_star", 3);
                    }
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }
    }
}
