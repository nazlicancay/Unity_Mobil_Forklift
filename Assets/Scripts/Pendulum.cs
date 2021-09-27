using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    /// <summary>
    /// moving the pendulums by forming the swing motion by 4 stage.
    /// </summary>

    #region varaiables

    float timer = 0f;
    float speed = 2f;
    int phase = 0;

    #endregion


    #region Mono Functions
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer > 1f)
        {
            phase ++;
            phase %= 4;            
            timer = 0f;
        }

        switch(phase)
        {
            case 0:
                transform.Rotate(0f, 0f, speed * (1 - timer));  // first quarter
                break;
            case 1:
                transform.Rotate(0f, 0f, -speed * timer);       //second quarter
                break;
            case 2:
                transform.Rotate(0f, 0f, -speed * (1 - timer)); //thirt quarter
                break;
            case 3:
                transform.Rotate(0f, 0f, speed * timer);        //fourt quarter 
                break;
        }
    }
    

    #endregion
    
}
