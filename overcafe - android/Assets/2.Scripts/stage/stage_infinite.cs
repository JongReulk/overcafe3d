using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage_infinite : MonoBehaviour
{
    private int score_infinite;
    private int score;
    private int bestScore;
    public Text BestScore_infinite;

    private bool checkScore;
    private void Awake()
    {
        PlayerPrefs.SetInt("Stage", 200);
    }

    // Start is called before the first frame update
    void Start()
    {
        score_infinite = PlayerPrefs.GetInt("score_infinite", 0);
        

        checkScore = false;

    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.scoreResult;
        score_infinite = PlayerPrefs.GetInt("score_infinite", 0);

        if (GameManager.instance.isGameOver)
        {
            if (score > score_infinite)
            {
                bestScore = score;
                PlayerPrefs.SetInt("score_infinite", bestScore);
            }
            BestScore_infinite.text = score_infinite.ToString();

            
        }
    }
}
