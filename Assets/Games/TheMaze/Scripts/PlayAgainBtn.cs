using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
  public static event System.Action OnPlayAgain;


   public void PlayAgain()
    {
      print("here");
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );

    }
}
