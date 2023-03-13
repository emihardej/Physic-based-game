using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameScenes : MonoBehaviour
{   
    public void Restart()
    {
        //Load Game scene
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        //Load Main menu
        SceneManager.LoadScene(0);
    }

}
