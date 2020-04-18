using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingUI : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //=================================================================================
    Text text;
    [SerializeField] private float bulletDelay;

    //=================================== Objects ===================================
    public Shooting shooting;
    public PlayerStats player;

    
    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 

    void Start()
    {
        bulletDelay = player.getDelay();
        text = GetComponent<Text>(); 
        
    }
    //======================
    void Update()
    {
        bulletDelay = player.getDelay();
        setDelay(bulletDelay);
    }
    //======================
    public void setDelay(float delay)
    {
        text.text = bulletDelay.ToString();
    }


}
