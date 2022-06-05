using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
   public Text playerDisplay;
   public Text scoreDisplay;

    private void Awake(){
        if (dbmanager.username == null){
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
        playerDisplay.text = "player: " + dbmanager.username;
        scoreDisplay.text = "score: " + dbmanager.score;
        
    }

    public void CallSaveData(){
        StartCoroutine(SavePlayerData());
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void IncreaseScore(){
        dbmanager.score++;
        scoreDisplay.text = "score: " + dbmanager.score;
    }

}
