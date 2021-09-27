﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class SteeringWheelController :Singleton<SteeringWheelController>,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    /// <summary>
    /// Responsible for the Steering Wheels control
    /// </summary>

    #region varaiables
    
    private bool beingheld = false;
    public RectTransform wheel;
    private float wheelAngle = 0f;
    private float lastWheelAngle = 0f;
    private Vector2 center;
    public float maxSteerAngle = 200f;
    public float releaseSpeed = 300f;
    public float outPut;

    public GameObject forklift;
    

    #endregion



    #region Mono Functions
    void Update()
    {
        if(!beingheld&&wheelAngle != 0f)
        {
            float deltaAngle = releaseSpeed * Time.deltaTime;
            if (Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle))
                wheelAngle = 0f;
            else if (wheelAngle > 0f)
                wheelAngle -= deltaAngle;
            else
                wheelAngle += deltaAngle;
        }
        wheel.localEulerAngles = new Vector3(0, 0, -maxSteerAngle*outPut);
        outPut = wheelAngle / maxSteerAngle;
        var position = forklift.transform.position;


    }
    public void OnPointerDown(PointerEventData data)
    {
        beingheld = true;
        center = RectTransformUtility.WorldToScreenPoint(data.pressEventCamera, wheel.position);
        lastWheelAngle = Vector2.Angle(Vector2.up, data.position - center);
    }
    public void OnDrag(PointerEventData data)
    {
        float newAngle = Vector2.Angle(Vector2.up, data.position - center);
        if((data.position-center).sqrMagnitude >= 400)
        {
            if (data.position.x > center.x)
                wheelAngle += newAngle - lastWheelAngle;
            else
                wheelAngle -= newAngle - lastWheelAngle;
        }
        wheelAngle = Mathf.Clamp(wheelAngle, -maxSteerAngle, maxSteerAngle);
        lastWheelAngle = newAngle;
    }
    public void OnPointerUp(PointerEventData data)
    {
        OnDrag(data);
        beingheld = false;
    }
    

    #endregion
   
}
