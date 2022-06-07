using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class stageFinal : MonoBehaviour
{
    public Text StageName4_6;
    public Text BestScore4_6;
    private int score;
    private bool checkScore;
    private int score_4_6;
    private int score_4_6_star;
    private int bestScore;
    public GameObject StoryButton;
    public GameObject MenuButton;
    public GameObject RetryButton;

    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 100);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageName4_6.text = "Final stage";
        score_4_6 = PlayerPrefs.GetInt("score_4_6", 0);
        score_4_6_star = PlayerPrefs.GetInt("score_4_6_star", 0);

        checkScore = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = GameManager.instance.scoreResult;
        score_4_6 = PlayerPrefs.GetInt("score_4_6", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_4_6)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_4_6", bestScore);
            }
            BestScore4_6.text = score_4_6.ToString();

            if (!checkScore)
            {
                if (score > 700)
                {
                    GameManager.instance.star_1 = true;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = false;

                    if (score_4_6_star < 1)
                    {
                        PlayerPrefs.SetInt("score_4_6_star", 1);
                    }
                    print("stage one 1 star");

                }

                if (score > 1000)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = true;
                    GameManager.instance.star_3 = false;

                    if (score_4_6_star < 2)
                    {
                        PlayerPrefs.SetInt("score_4_6_star", 2);
                    }
                    print("stage one 2 star");
                }

                if (score > 1500)
                {
                    GameManager.instance.star_1 = false;
                    GameManager.instance.star_2 = false;
                    GameManager.instance.star_3 = true;

                    if (score_4_6_star < 3)
                    {
                        PlayerPrefs.SetInt("score_4_6_star", 3);
                    }
                    print("stage one 3 star");
                }

                if (score > 700)
                //if (score > 5)
                {
                    MenuButton.SetActive(false);
                    StoryButton.SetActive(true);
                    RetryButton.SetActive(false);
                }


                checkScore = true;

            }

        }
    }
}
