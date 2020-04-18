using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingUICost : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //=================================================================================
    Text text;
    [SerializeField] private int price;
    //=================================== Objects ===================================
    public PlayerStats player;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void Start()
    {
        price = player.getBulletCost();
        text = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        price = player.getBulletCost();
        setcost(price);
    }
    public void setcost(int cost)
    {
        text.text = cost.ToString();
    }

}
