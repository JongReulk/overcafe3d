using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class stageTwobyseven : MonoBehaviour
{
    public Text StageName2_7;
    public Text BestScore2_7;
    private int score;
    private bool checkScore;
    private int score_2_7;
    private int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        StageName2_7.text = "2-7 stage";
        score_2_7 = PlayerPrefs.GetInt("score_2_7", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_2_7 = PlayerPrefs.GetInt("score_2_7", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_2_7)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_2_7", bestScore);
            }
            BestScore2_7.text = score_2_7.ToString();

            if (!checkScore)
            {
                if (score > 240)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;
                    print("stage one 1 star");

                }

                if (score > 280)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;
                    print("stage one 2 star");
                }

                if (score > 320)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;
                    print("stage one 3 star");
                }

                checkScore = true;
            }

        }
    }
}
