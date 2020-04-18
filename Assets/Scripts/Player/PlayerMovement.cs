using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
    [SerializeField]public float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void Update()
    {
        //Get inputs form both axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //When movement is detected
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Rotates player to look at the cursor position
        Vector2 lookDir = mousePos- rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;
    }
}
