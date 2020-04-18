using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
    float scrollspeed = -10f;
    [SerializeField] private Vector2 startPos;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 

    void Start()
    {
        startPos = transform.position;
    }
    //======================
    void Update()
    {
        //Scrolls Menu background
        float newPos = Mathf.Repeat (Time.time * scrollspeed, 66);
        transform.position=startPos + Vector2.right * newPos;
    }
}
