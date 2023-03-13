﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text endScoreText;
    public Text highScoreText;
    public static int score = 0;
    public static int endScore = 0;
    int highScore = 0;

    private void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        endScoreText.text = endScore.ToString();
        highScoreText.text = highScore.ToString();
    }
// Add point to score
    public void AddPoint()
    {
        score += 1;
        endScore += 1;
        scoreText.text = score.ToString();
        endScoreText.text = endScore.ToString();
        //if current level score is higher than high score, save high score
        if (highScore < score){
            PlayerPrefs.SetInt("highscore", score);
        }
    }
// Reset score on restart
    public void ResetScore()
    {
        score = 0; 
        endScore = 0;
    }
}
