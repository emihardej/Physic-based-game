using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    //public Text highScoreText;

    int score = 0;
    //int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        //highScoreText.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
