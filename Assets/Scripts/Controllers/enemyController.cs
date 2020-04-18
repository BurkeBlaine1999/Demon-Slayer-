using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 

    // =============================== Bullets/Firing =================================
    [SerializeField] private bool dead = false;
    [SerializeField] private Vector3 position;

    // =================================== Money =========================================
    [SerializeField] private int coins = 10;

    // =================================== Health ========================================
    [SerializeField] private float health =30;
    [SerializeField] private GameObject Heart;
    // =================================== Damage ========================================
    [SerializeField] private int currentDamage;
    [SerializeField] private GameObject rapidFire;

    // =================================== Audio =========================================
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume=0.5f;

    // =================================== Objects =======================================
    coinCounter counter;
    public PlayerStats player;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
   
    void Start()
    {
        //get coincounter in order to add and keep track of coins
        //received from 
        counter = FindObjectOfType<coinCounter>();
        position = transform.position;

        //Set Health and Coins to Enemies depending on Tags
         if(gameObject.tag == "Spinning-blade")
         {
             health = 30f;
             coins = 10;
         }    
         else if(gameObject.tag == "small-spinning-blade")
         {
             health = 10f;
             coins = 15;
         }
        else if(gameObject.tag == "big-spinning-blade")
         {
             health = 60f;
             coins = 20;
         }
    }
    //======================
    void Update()
    {
        //Get position for dropping power ups
        position = transform.position;
        currentDamage = player.getDamage();
        setDamage(currentDamage);
    }
// ==================================== Damage ===========================================
    public void setDamage(int damage)
    {
        //Damage taken by enemy
        currentDamage = damage;
    }
    //=====================================================================================
    void OnCollisionEnter2D(Collision2D collision)
    {  
        Debug.Log("Collided");

        //If hit with bullet take damage
        if(collision.gameObject.tag == "Bullet")
        {              
            health = health - currentDamage;
            Debug.Log("Taken Damage " + health);

            if(health <= 0)
            {        
                //Random drop of heart or rapid fire       
                var number = Random.Range(1,150);
                if(number > 1 && number < 15)
                {
                    Debug.Log("HEART DROPPING");
                    Instantiate(Heart,position,Quaternion.identity);
                }  
                if(number > 85 && number < 90)
                {                   
                    Instantiate(rapidFire,position,Quaternion.identity);
                }  

                //Destroy enemy
                Destroy(gameObject);         

                //Grant player coins
                counter.IncreaseCoinCount(coins);
                counter.IncreaseDeathCount();
                
            }            
        }
    }
}
