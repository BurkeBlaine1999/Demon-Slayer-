using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
    [SerializeField] private GameObject hitEffect;
    [SerializeField]private float bulletLife = 3f;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy bullet if it hits anything
         Destroy(gameObject);
    }

    void Update()
    {
        //Destroy bullet if it hits anything
        Destroy(gameObject,bulletLife);
    }

}
