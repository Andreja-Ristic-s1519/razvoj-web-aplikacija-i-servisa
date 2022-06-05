using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public Text scoreDisplay;
    public int rezultat = 0;
    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        scoreDisplay.text = "score: " + rezultat;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left ;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
    }
    public void IncreaseScore(){
        rezultat++;
        scoreDisplay.text = "score: " + rezultat;
        
        if (rezultat > dbmanager.score){
            dbmanager.score = rezultat;
        }
    }

    private async void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i-- )
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private async void ResetState()
    {
        for (int i=1; i< _segments.Count; i++){
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
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

        // dbmanager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Food")
       {    
       Grow();
       IncreaseScore();
       
      
       }
       else if ( other.tag == "Wall") 
       {

        //    UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        StartCoroutine(SavePlayerData());
        
       }
   }
}
