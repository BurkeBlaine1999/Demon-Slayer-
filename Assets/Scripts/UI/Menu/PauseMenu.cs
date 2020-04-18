using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 

    [SerializeField] private static bool GameisPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void Start () 
    {
        //Turn off the pause menu
        pauseMenuUI.SetActive (false);
    }

    void Update () {
    if (Input.GetKeyDown(KeyCode.Escape))//Pause the game
    {
        if (GameisPaused){
            Resume ();
        } else {
            Pause ();
        }
    }
}

    //=================================================================================
    //=================================== Menu Options ================================
    //================================================================================= 
    public void Resume ()
    {
        pauseMenuUI.SetActive (false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    //======================
    public void Pause ()
    {
        pauseMenuUI.SetActive (true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    //======================
    public void LoadMenu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    //======================
    public void QuitGame ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        //Application.Quit();
    }
}