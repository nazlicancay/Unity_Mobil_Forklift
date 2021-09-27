using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    #region Mono Functions
    
    /// <summary>
    ///  moving the lift
    /// </summary>

    
    // moving the forklifts lift up and down
    public void ElevateLift()
    {
        if (UIManager.Instance.liftUp && transform.position.y < 8)
        {
           
            transform.position += Vector3.up * Time.deltaTime;
            
        }

        else
        {
            UIManager.Instance.liftUp = false;
        }

        if (UIManager.Instance.liftDown && transform.position.y > 4.5)
        { 

            transform.position += Vector3.down * Time.deltaTime;
            
        }

        else
        {
            UIManager.Instance.liftDown = false;
        }
        
    }
    
    void Update()
    {
        
        ElevateLift();
        
    }
    
    #endregion
    
    
 

   
}
