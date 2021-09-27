using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasTank : MonoBehaviour
{
    /// <summary>
    /// functions for setting the max gas, decresing gas and adding gas
    /// </summary>
    
    #region varaiables
    public Slider slider;
    public int currentgas;
    public bool moreGas;
    public float time;


    #endregion



    #region Mono Functions

    private void Awake()
    {
        SetMaxGas(100);
        currentgas = 100;
    }

   
    void Update()
    {
        time = time + Time.deltaTime;

        if (currentgas <= 0)
        {
            GameManager.Instance.ReloadGame();
        }


        if (moreGas)
        {
            AddGas(); 
        }

        // decreesing the gas by time
        
        if (time > 3)
        {
            DecreseGas();
            time = 0;
        }

    }
    
    // setting the foklifts gas to maximum
    public void SetMaxGas(int maxGas)
    {
        slider.maxValue = maxGas;
        slider.value = maxGas;
        GasBar.Instance.fill.color = GasBar.Instance.gradient.Evaluate(1f);


    }
    
    // chancing the gas 
    public void SetGas(int gas)
    {
        slider.value = gas;

        GasBar.Instance.fill.color = GasBar.Instance.gradient.Evaluate(slider.normalizedValue);
    }
   
    // decreesing the gas 
    public void DecreseGas( )
    {
        currentgas = currentgas -4;
        SetGas(currentgas);
    }
    
    // addding gas when a gas obj has picked up
    public void AddGas()
    {
        moreGas = false;
        currentgas += 6;
        SetGas(currentgas);
        Debug.Log("Added gas");

    }


    #endregion
 

 
}
