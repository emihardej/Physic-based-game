using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public float timeVal = 90;
    public Text timeText;
    // Update is called once per frame
    void Update()
    {
        if (timeVal > 0)
        {
            timeVal -= Time.deltaTime;
            Timer(timeVal);
        }
        else
        {
            Debug.Log("Times up!");
            gameOverMenu.SetActive(true);
            //bool player = GetComponent<CharController>().enabled = false;
            timeVal = 0;
        }
        
    }

    // Update and display current time on timer
    void Timer(float currentTime)
    {
        if (currentTime < 0)
        {
            currentTime = 0;
        }
        else if (currentTime > 0)
        {
            currentTime += 1;
        }

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
