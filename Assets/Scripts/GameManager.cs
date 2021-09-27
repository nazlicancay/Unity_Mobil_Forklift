using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    /// <summary>
    /// function to reload the game when a liftable has fallen , gas has ended , hit by a pendulum 
    /// </summary>

    #region Mono Function

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);

    }

    #endregion
   

   
}
