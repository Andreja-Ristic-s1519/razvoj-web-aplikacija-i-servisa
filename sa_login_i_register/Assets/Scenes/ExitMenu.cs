using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public void Exit(){

            Application.Quit();

    }
   
     public void GoToGame()
   {
    SceneManager.LoadScene(3);
   }

   public void GoToLeaderboard()
   {
    SceneManager.LoadScene(6);
   }

}
