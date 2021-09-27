using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    /// <summary>
    /// responsible for controlling the UI elements of the game.
    /// functions to work when brake, reverse, gas buttons and forklifts lifts up and down buttons
    /// </summary>
    

    #region varaibles
    
    public GameObject player;
    [HideInInspector] public bool gasPressed = false;
    [HideInInspector] public bool breakPressed = false;
    [HideInInspector] public bool reversePressed = false;
    private Rigidbody rb;
    private string drection;
    [HideInInspector] public bool liftUp = false ;
    [HideInInspector] public bool liftDown = false ;

    [HideInInspector] public const string Vertıcal = "Vertical";

    

    #endregion


    #region Mono Funvtions
    
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        
    }
    
    void Update()
    {

        if (!liftDown && ! liftUp)
        {
            CameraManager.Instance.ActivateCamera(1);
        }
        else
        {
            CameraManager.Instance.ActivateCamera(0);
        }

        if (reversePressed)
        {
            CameraManager.Instance.ActivateCamera(2);
        }

        if (breakPressed && rb.velocity != Vector3.zero)
        {
            rb.velocity = rb.velocity * 0.95f * Time.deltaTime;
          
        }
        
    }

    public void Gas()
    {
        breakPressed = false;
        gasPressed = true;
        ForkliftController.Instance.verticalInput = ForkliftController.Instance.speed;

       // Debug.Log("Gas was pressed");
    }

    public void StopGas()
    {
        gasPressed = false;
        ForkliftController.Instance.verticalInput = 0;
       // Debug.Log("Gaz bırakıldı");
        
    }
    
    
    
    public void Brake()
    {
        reversePressed = false;
       
        breakPressed = true;
     
       // Debug.Log("Break was pressed");

    }
   
    public void Reverse()
    {
        reversePressed = true;
       // Debug.Log("Reversed was pressed");
    }

    public void LiftUp()
    {
        liftUp = true;
    }

    public void LiftDown()
    {
        liftUp = false;
        liftDown = true;
    }




    

    #endregion
  

}
