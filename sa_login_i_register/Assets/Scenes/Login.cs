using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin(){
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            dbmanager.username = nameField.text;
            dbmanager.score = int.Parse(www.text.Split('\t')[1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }
        else
        {
            Debug.Log("Login faled. Error:" + www.text);
        }
    }

     public void VerifyInputs(){
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 5);
    }
}
