using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCounter : MonoBehaviour
{

    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 

    [SerializeField] private int numCoins;
    [SerializeField] private int numDeaths;
    //=================================== OBJECTS ===================================
    public PlayerStats player;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 

    void Start()
    {
        numDeaths = 0;
    }
    //======================
    void Update()
    {
        Debug.Log("You Have " + numCoins + " Coins");
    }

    //=================================== Counters ====================================
    public void setCoinCount(int coins)
    {
        numCoins += coins;
    }
    //======================
    public void IncreaseCoinCount(int coins)
    {
        //numCoins += coins;
        player.addCoins(coins);
    }
    //======================
    public void IncreaseDeathCount()
    {
        numDeaths++;
    }
    //======================
    public int getDeathCount()
    {
        return numDeaths;
    }
    //======================
    public int getCoinCount()
    {
        return numCoins;
    }
}
