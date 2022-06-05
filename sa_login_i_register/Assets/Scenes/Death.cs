using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Death : MonoBehaviour
{
    public Text theScore;

    void Start()
    {
        StartCoroutine(GetTheScore());
    }

    
      
    

    IEnumerator SavePlayerData(){
        WWWForm form = new WWWForm();

        form.AddField("name", dbmanager.username);
        form.AddField("score", dbmanager.score);

        WWW www = new WWW ("http://localhost/sqlconnect/savedata.php",form);
        yield return www;
        if (www.text == "0"){
            Debug.Log("Game Saved");
        }
        else
        {
            Debug.Log("Save failed. Error: " + www.text);
        }

        dbmanager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    
    IEnumerator GetTheScore()
    {
        if (dbmanager.LoggedIn)
        {
            Debug.Log(dbmanager.username);
            WWWForm form = new WWWForm();
            form.AddField("name", dbmanager.username);
              WWW www = new WWW("http://localhost/sqlconnect/getthescore.php", form);
            yield return www;

            if (www.error != null)
            {
                print("There was an error getting the high score: " + www.error);
            }
            else
            {
                theScore.text = "Highscore: " + dbmanager.score;
                // theScore.text = dbmanager.score;
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToMainMenu()
    {
          StartCoroutine(SavePlayerData());
    }
}
