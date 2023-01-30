using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    //public Text highScoreText;
    int score = 0;
    //int highScore = 0;

    private void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        //highScoreText.text = highScore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
        //if (highScore < score){
        //    PlayerPrefs.SetInt("highscore", score);
        //}
    }
}
