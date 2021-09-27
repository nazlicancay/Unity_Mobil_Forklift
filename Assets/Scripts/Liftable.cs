using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Liftable : MonoBehaviour
{
    #region variables
    public Rigidbody rb;
    public bool _amILifted = false;
    public bool _rightPlace = false;

    

    #endregion


    #region Mono Functions
    private void Update()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("drapPoint"))
        {
            _rightPlace = true;
        }
    }

    

    #endregion
  
    public bool AmILifted
    {
        get => _amILifted;
        set => _amILifted = value;
    }


   
}
