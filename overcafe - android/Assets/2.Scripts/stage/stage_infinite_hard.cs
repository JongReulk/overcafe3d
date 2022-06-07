using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage_infinite_hard : MonoBehaviour
{
    private int score_infinite_hard;
    private int score;
    private int bestScore;
    public Text BestScore_infinite_hard;

    private bool checkScore;
    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 250);
    }

    // Start is called before the first frame update
    void Start()
    {
        score_infinite_hard = PlayerPrefs.GetInt("score_infinite_hard", 0);


        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_infinite_hard = PlayerPrefs.GetInt("score_infinite_hard", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_infinite_hard)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_infinite_hard", bestScore);
            }
            BestScore_infinite_hard.text = score_infinite_hard.ToString();


        }
    }
}
