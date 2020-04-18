using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUICost : MonoBehaviour
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
        price = player.getDamageCost();
        text = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        price = player.getDamageCost();
        setcost(price);
    }
    public void setcost(int cost)
    {
        text.text = cost.ToString();
    }
}
