using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
 
    [SerializeField] private  bool Dead;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject PlayerDeadUI;
    [SerializeField] private static bool GameisPaused = false;

    //=================================== Objects ===================================
       public coinCounter counter;
    
    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
        void Start () 
    {
        GameOverUI.SetActive (false);
        PlayerDeadUI.SetActive (false);
        Dead = false;
    }

    //======================

    void Update () {
        Isdead(Dead);

        if(Dead == true)
        {
            Debug.Log("Finish Screen");
            Time.timeScale = 0f;
            PlayerDeadUI.SetActive(true);
        }

    }

    //======================

    public void Isdead(bool isDead)
    {
        Dead = isDead;
    }

    //======================

    public void QuitGame ()
    {
        Debug.Log("Quitting");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    //======================

    public void portalBought(bool victory)
    {
        Debug.Log("PURCHASED PORTAL");
        if(victory == true)
        {
            Debug.Log("Finish Screen");
            Time.timeScale = 0f;
            GameOverUI.SetActive (true);
        }
    }

}
