using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




    public class ForkliftController : Singleton<ForkliftController>
    {
        /// <summary>
        /// responsible for controlling the UI elements of the game.
        /// functions to work when brake, reverse, gas buttons and forklifts lifts up and down buttons
        /// </summary>


        #region variables

        private const string Horızontal = "Horizontal";
        private const string Vertıcal = "Vertical";

        public GasTank gasTank;
        private float horizontalInput;
        public float verticalInput;
        private float currentSteerAngle;
        private float currentbreakForce;
        private bool isBreaking;
        public float speed;

        [SerializeField] private float motorForce;
        [SerializeField] private float breakForce;
        [SerializeField] private float maxSteerAngle;

        [SerializeField] private WheelCollider frontLeftWheelCollider;
        [SerializeField] private WheelCollider frontRightWheelCollider;
        [SerializeField] private WheelCollider rearLeftWheelCollider;
        [SerializeField] private WheelCollider rearRightWheelCollider;

        [SerializeField] private Transform frontLeftWheelTransform;
        [SerializeField] private Transform frontRightWheeTransform;
        [SerializeField] private Transform rearLeftWheelTransform;
        [SerializeField] private Transform rearRightWheelTransform;



        #endregion

        #region Mono Function

         private void FixedUpdate()
    {
        GetInput();
        Engine();
        Steering();
        UpdateWheels();
        
        if (UIManager.Instance.reversePressed && UIManager.Instance.gasPressed)
        {
            ReverseEngine();
        }
    }


    private void GetInput()
    {
        horizontalInput = SteeringWheelController.Instance.outPut;
    }

    private void Engine()
    {
        
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
    }
 public void ReverseEngine()
    {
        frontLeftWheelCollider.motorTorque = - verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = - verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
    }

 
    private void Steering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
       wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("gas"))
        {
            Debug.Log("on triger enter");
            gasTank.AddGas();
            gasTank.moreGas = true;
    //      Debug.Log("gas");
            Destroy(other.gameObject);
        }

       
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("pendulum"))
        {
            UIManager.Instance.Brake();
            Debug.Log("game over");
            GameManager.Instance.ReloadGame();
        }

        if (other.gameObject.CompareTag("fall"))
        {
            GameManager.Instance.ReloadGame();
        }
    }
    

        #endregion
   
  
    }

