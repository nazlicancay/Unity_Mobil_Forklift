using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftChamber : MonoBehaviour
{
    #region Mono Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("liftable"))
        {
            Liftable liftable = other.gameObject.GetComponent<Liftable>();
            liftable.AmILifted = true;
            // Debug.Log("am ı lifted true");
        }
     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("liftable"))
        {
            Liftable liftable = other.gameObject.GetComponent<Liftable>();
            liftable.AmILifted = false;
            // Debug.Log("am ı lifted false");
            GameManager.Instance.ReloadGame();

        }
       
    }
    

    #endregion
  
}
