using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coins : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
    Text text;
    [SerializeField] private int coinAmount;

    //=================================== OBJECTS ===================================
    public PlayerStats player;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void Start()
    {
        text = GetComponent<Text>();
        coinAmount = player.getCoins();
    }
    //======================
    void Update()
    {
        coinAmount = player.getCoins();
        setCoins(coinAmount);   
    }

    //=================================== Setters =====================================
    public void setCoins(int coins)
    {
        //Updates UI 
        text.text = coins.ToString();
    }
}
