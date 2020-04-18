using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 
    [SerializeField] private GameObject player;

    
    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void Update()
    {
        Vector3 offset = transform.position - player.transform.position;
        bool changeInX = false;
        bool changeInY = false;
        Vector3 newCameraPosition = transform.position;

        //Follow character on the X-Axis
        if (offset.x > 3)
        {
            changeInX = true;
            newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x - 3);
        }
        else if (offset.x < -3)
        {
            changeInX = true;
            newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x + 3);
        }
        if (!changeInX)
        {
            newCameraPosition.x = transform.position.x;
        }
        //Follow character on the Y-Axis
          if (offset.y > 2)
          {
              changeInY = true;
              newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y - 2);
          }
          else if (offset.y < -2)
          {
              changeInY = true;
              newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y + 2);
          } 

            if (!changeInY)
            {
                newCameraPosition.y = transform.position.y;
            } 
            
        //Update Camera position
        transform.position = newCameraPosition;
    }
}
