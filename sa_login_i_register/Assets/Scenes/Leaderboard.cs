using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public string highscoreURL = "http://localhost/sqlconnect/getscores.php";

  
    public Text TxtTop;

    void Start()
    {
        StartCoroutine(GetScores());
    }

  
    IEnumerator GetScores()
    {
        TxtTop.text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            TxtTop.text = hs_get.text;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(5);
    }
}

