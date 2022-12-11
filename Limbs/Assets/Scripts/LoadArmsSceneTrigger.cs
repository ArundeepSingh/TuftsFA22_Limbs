using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArmsSceneTrigger : MonoBehaviour
{
    private GameController gc;

    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.CompareTag("Player")) {
            // REAL POS
            //gc.PlayerPos = new Vector3(20f, -14f, 0f);
            // TESTING POS
            Debug.Log("door is triggered");
            gc.PlayerPos = new Vector3(25f, -48f, 0f);
            gc.LoadScene("Arms");          
        }
    }
}