using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageThreebytwo : MonoBehaviour
{
    public Text StageName3_2;
    public Text BestScore3_2;
    private int score;
    private bool checkScore;
    private int score_3_2;
    private int score_3_2_star;
    private int bestScore;
    public GameObject StoryButton_3_2;
    public GameObject MenuButton_3_2;
    public GameObject RetryButton_3_2;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName3_2.text = "3-2 stage";
        score_3_2 = PlayerPrefs.GetInt("score_3_2", 0);
        score_3_2_star = PlayerPrefs.GetInt("score_3_2_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_3_2 = PlayerPrefs.GetInt("score_3_2", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_3_2)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_3_2", bestScore);
            }
            BestScore3_2.text = score_3_2.ToString();

            if (!checkScore)
            {
                if (score > 220)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_3_2_star < 1)
                    {
                        PlayerPrefs.SetInt("score_3_2_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 260)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_3_2_star < 2)
                    {
                        PlayerPrefs.SetInt("score_3_2_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 300)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_3_2_star < 3)
                    {
                        PlayerPrefs.SetInt("score_3_2_star", 3);
                    }
                    print("stage one 3 star");
                }

                if (score > 220)
                {
                    MenuButton_3_2.SetActive(false);
                    StoryButton_3_2.SetActive(true);
                    RetryButton_3_2.SetActive(false);
                }

                checkScore = true;
            }

        }
    }
}
