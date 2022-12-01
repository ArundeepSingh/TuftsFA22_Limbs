using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public MonoBehaviour OrigMovement;
    public MonoBehaviour LadderMovement;
    private GameController gc;

    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.CompareTag("Player")) {
            gc.LoadEyesScene();
        }
    }
}
