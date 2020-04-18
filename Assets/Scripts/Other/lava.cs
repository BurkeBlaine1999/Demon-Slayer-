using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class lava : MonoBehaviour
{      
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
    public GameObject player;

    //=================================== Objects ====================================
    public PlayerStats playerStats;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage the player when they touch Lava
        if(collision.gameObject.tag == "Player")
        {
            playerStats.TakeDamage(5);
            if(playerStats.currentHealth <= 0)
            {
                Destroy(player);
            }     
        }
    }
}
