using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 

    // =============================== Bullets/Firing =================================
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Coroutine firingCoroutine;
    [SerializeField] private bool rapidfire;
    [SerializeField] private float fireTimer;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField]private float bulletDelay;
    [SerializeField] private float bulletTimer;
    [SerializeField] private static int DelayAmount;

    // ==================================== Audio =====================================
    public AudioClip clip;
    public SoundController sound;
    public AudioSource audioSource;
    private float volume=0.7f;

    // ==================================== Objects ====================================
    public PlayerStats player;
    public GameObject bulletParent;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 

    void Start()
    {
        fireTimer = 5f;
        bulletDelay = player.getDelay();
        bulletTimer = bulletDelay;
        GetComponent<AudioSource>();

        //Puts all bullets as children of the Bullet Parent Gameobject
        bulletParent = GameObject.Find("BulletParent");
        if (!bulletParent)
        {
            bulletParent = new GameObject("BulletParent");
        }
    }

    //======================

    void Update()
    {
        
        bulletDelay = player.getDelay();
        bulletTimer -= Time.deltaTime;//Keep The bullet timer counting down

    //=========== Delayed Shots Controller ==========
        if(rapidfire == false){
            if(Input.GetButtonDown("Fire1"))
            {
                Debug.Log("CLICKED");
                if ( bulletTimer <= 0 )
                {
                    Debug.Log("SHOOTING");
                    Shoot();
                    bulletTimer = bulletDelay;
                }
    
            }
            StopCoroutine(firingCoroutine);
        }

    //=========== Rapid Fire Controller ==========
        if(rapidfire == true){

            Debug.Log("Entered While Loop");
            fireTimer -= Time.deltaTime;
            Debug.Log("Time left " + fireTimer);

            if(fireTimer <= 0)//Stop Rapid Fire
            {
                rapidfire = false;//Reset rapidFire to false 
                fireTimer = 5f;//Reset fire Timer
                player.setRapidFire(rapidfire);//Update rapidfire in PlayerStats
            }
            if(fireTimer > 0)//Keep Rapid Fire
            {
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    // setup a co routine to fire the bullets - start firing
                    firingCoroutine = StartCoroutine(FireCoroutine());
                    //FireBullet();
                    Debug.Log("FIRING");
                }
            }

            if(Input.GetKeyUp(KeyCode.Mouse0))// stop firing
            {  
                StopCoroutine(firingCoroutine);
            }
        }


        setRapidFire(rapidfire);
    }


    // ==================================== Shooting ====================================
    public void Shoot()
    {
        audioSource.PlayOneShot(clip, volume);
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation,bulletParent.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
    //======================
    private IEnumerator FireCoroutine()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(0.1f);
        }
    }

    // ==================================== Setters  ====================================
    public void setRapidFire(bool isRapid)
    {
        rapidfire =  isRapid;
    }
}
