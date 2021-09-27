using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    /// <summary>
    /// Responsible for moving the platforms
    /// </summary>
    #region varaiables
    
    public bool moveLeft = true;
    public bool moveRight = false;
    

    #endregion


    #region Mono Functions

    void Update()
    {
        if (moveLeft)
        {
            transform.position += Vector3.left * Time.deltaTime * 8;
        }

        if (transform.position.x < -40)
        {
            moveLeft = false;
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position += Vector3.right * Time.deltaTime * 8;
        }

        if (transform.position.x > 40)
        {
            moveRight = false;
            moveLeft = true;
        }

        
    }


    #endregion
    
   
}
