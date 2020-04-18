using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //=================================================================================== 
    //=================================== Variables ===================================
    //================================================================================= 

    // ==================================== Wallet/Buyables ===========================
    [SerializeField] private int Wallet;
    [SerializeField] private bool bought;
    [SerializeField] private int increase_Damage_cost = 100;
    [SerializeField] private int increase_Bullet_cost = 50;
    [SerializeField] private int portalCost = 1000;

    // ==================================== Health ====================================
    [SerializeField] private int maxHealth= 100;
    public int currentHealth;

    // ==================================== Damage ====================================

    [SerializeField] private int currentDamage ;
    [SerializeField] private float bulletDelay;
    [SerializeField] private bool rapidfire;
    //==================================== OBJECTS ====================================
    public static PlayerStats playerStats;
    public enemyController enemyController;
    public ShootingUI shooting;
    public Shooting shoot;
    public coinCounter coinCounter;
    public GameOver gameOver;
    public DamageUI damageUI;
    public Bullet bullet;
    public healthbar healthbar;
    public Coins coinsUI;
    public ShootingUICost shootingUICost;
    public DamageUICost damageUICost;
    
//=====================================================================================  
//=================================== Functions =======================================
//=====================================================================================  
    void awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else{
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

  
//=====================================================================================  
    void Start()
    { 

        //Initialize values for variables
        maxHealth = 100;
        bulletDelay = 1.2f;
        Wallet = 100;       
        currentDamage = 10;
        bought = false;
        rapidfire = false;
        currentHealth = maxHealth;  

        //Initialize values in scipts
        healthbar.SetMaxHealth(maxHealth);
        coinCounter.setCoinCount(Wallet);
        enemyController.setDamage(currentDamage);
        damageUI.setDamage(currentDamage);
        shooting.setDelay(bulletDelay);
        coinsUI.setCoins(Wallet);
        shootingUICost.setcost(increase_Bullet_cost);
        damageUICost.setcost(increase_Damage_cost);
    }

//=====================================================================================  
    void Update()
    {
        //Keeping scripts updated
        damageUI.setDamage(currentDamage);
        shooting.setDelay(bulletDelay);
        coinsUI.setCoins(Wallet);
        shoot.setRapidFire(rapidfire);
        shootingUICost.setcost(increase_Bullet_cost);
        damageUICost.setcost(increase_Damage_cost);
    }

//=====================================================================================
//On Collision is  Used for Damaging the player
//=====================================================================================
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spinning-Blade")
        {
            TakeDamage(15);
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
                bool dead = true;
                gameOver.Isdead(dead);
            }     
        }
        else if(collision.gameObject.tag == "small-spinning-blade")
        {
            TakeDamage(10);
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }     
        }
        else if(collision.gameObject.tag == "big-spinning-blade")
        {
            TakeDamage(20);
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }     
        }

    }

//=====================================================================================
//On Triggers Used for power ups, healthdrops and purchasing Items
//=====================================================================================

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "increase_Damage")
        {
            Debug.Log("Wallet was : " + Wallet);

            if(Wallet >= increase_Damage_cost)
            {
                Wallet -= increase_Damage_cost;
                increase_Damage_cost = increase_Damage_cost * 2;
                currentDamage += 5;
                Debug.Log("You now do " + currentDamage);
                coinsUI.setCoins(Wallet);
                damageUI.setDamage(currentDamage);
                enemyController.setDamage(currentDamage);
            }
        }

//======================

        if(col.gameObject.tag == "Increase_bulletSpeed")
        {
            Debug.Log("Wallet was : " + Wallet);

            if(bulletDelay != 0)
            {
                if(Wallet >= increase_Bullet_cost)
                {
                    Wallet -= increase_Bullet_cost;
                    increase_Bullet_cost = increase_Bullet_cost * 2;
                    bulletDelay -= 0.2f;
                    coinsUI.setCoins(Wallet);
                    shooting.setDelay(bulletDelay);
                }
            }

        }

//======================

        if(col.gameObject.tag == "HealthDrop")
        {
            if(currentHealth != maxHealth)
            {
                Heal(25);   //Heal the Player by 25 HP
                Destroy(col.gameObject); //Dstroy the game object
            }
        }
//======================

        if(col.gameObject.tag == "RapidFire")
        {
            rapidfire = true;   //Set rapid fire to true
            shoot.setRapidFire(rapidfire); // Set rapid fire equal to true in Shooting.cs
            Destroy(col.gameObject); // Destroy Rapid Fire Power up
        }

//======================

        if(col.gameObject.tag == "Portal")
        {
            Debug.Log("Wallet was : " + Wallet);

            if(bulletDelay != 0)
            {
                if(Wallet >= portalCost)
                {
                    bought = true; //set bought = to true in ordre to end the game
                    Wallet -= portalCost; // remove 1000 from players Wallet
                    coinsUI.setCoins(Wallet); //Update WA=allet
                    gameOver.portalBought(bought); //End game
                }
            }
        }
    }

//=====================================================================================
    public void TakeDamage(int damage) //Player receives Damage from enemies
    {
        currentHealth -= damage;

        healthbar.setHealth(currentHealth);
    }

//=====================================================================================
    void Heal(int healed) // Heal player when they collect a heart drop
    {
        currentHealth += healed;
        
        if(currentHealth > 100)
        {
            currentHealth = 100;
        }

        healthbar.setHealth(currentHealth);
    }
//=====================================================================================
    public void addCoins(int reward) // Add coins upon killing enemies
    {
        Wallet += reward;       
        coinsUI.setCoins(Wallet);
        return;
    }

// ==================================== Getters ===========================================
    public int getCoins()
    {
        return Wallet;
    }
//======================
    public int getDamage()
    {
        return currentDamage;
    }
//======================
    public float getDelay()
    {
        return bulletDelay;
    }
//======================
    public int getBulletCost()
    {
        return increase_Bullet_cost;
    }
//======================
    public int getDamageCost()
    {
        return increase_Damage_cost;
    }

// ==================================== Setters ===========================================

    public void setBullets(float bullets)
    {
        Debug.Log(bullets);
        shooting.setDelay(bullets);
    }  
//======================
    public void setBulletCost(int increase_Bullet_cost)
    {
        shootingUICost.setcost(increase_Bullet_cost);
    }
//======================
    public void setDamageCost(int increase_Damage_cost)
    {
        damageUICost.setcost(increase_Damage_cost);
    }
//======================
    public void setRapidFire(bool isRapid)
    {
        rapidfire = isRapid;
        
        Debug.Log("Rapid fire = " + rapidfire);
    }


}

