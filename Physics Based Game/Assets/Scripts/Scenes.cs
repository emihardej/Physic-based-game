using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Scenes : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject mainCameraPos;
    private GameObject tutorialCameraPos;
    private bool atMainMenu;
    AudioSource audioSource;
    public AudioClip meow;
    public int speed = 1;
    public GameObject mainMenu;
    public GameObject creditsMenu;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;
        mainCameraPos = GameObject.Find("Main Camera Position");
        tutorialCameraPos = GameObject.Find("Marker");
        atMainMenu = true;
    }

//Switch to second tutorial camera
    public void Tutorial()
    {
        Vector3 mainCamPos= mainCamera.transform.position;
    
        if (atMainMenu)
        {
            mainMenu.SetActive(false);
           //mainCamPos = Vector3.Lerp(transform.position, tutorialCameraPos.transform.position, speed * Time.deltaTime);
            
           mainCamera.transform.position = tutorialCameraPos.transform.position;
           mainCamera.transform.rotation = tutorialCameraPos.transform.rotation;
            // Debug.Log(mainCameraPos.transform.position);
            // Debug.Log(tutorialCameraPos.transform.position);
            
        }
        
    }

//Switch to main start menu camera
    public void BackfromTutorial()
    {   
        atMainMenu = false;
        // Debug.Log(atMainMenu);
        // Debug.Log("hit");
        if (atMainMenu == false)
        {
            // Debug.Log("hit");
            mainMenu.SetActive(true);
            mainCamera.transform.position = mainCameraPos.transform.position;
            mainCamera.transform.rotation = mainCameraPos.transform.rotation;
            atMainMenu = true;
        }
    }
//Load game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
//Show credits panel
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
//Hide credits panel
    public void BackFromCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
// Quit Game
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(meow, 0.4f);
    }

}
