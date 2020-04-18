using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{

    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
    [SerializeField] private Text text;
    [SerializeField] private static int DMGAmount;
    //=================================== Objects =====================================
    public PlayerStats player;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void Start()
    {
        text = GetComponent<Text>();
        DMGAmount = player.getDamage();
    }
    //======================
    void Update()
    {
        DMGAmount = player.getDamage();
        setDamage(DMGAmount);
    }
    //=================================== Setters =====================================
    public void setDamage(int damage)
    {
        //Set Damage UI
        text.text = DMGAmount.ToString();
    }
}
