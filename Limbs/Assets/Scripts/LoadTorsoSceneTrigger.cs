using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTorsoSceneTrigger : MonoBehaviour
{
    private GameController gc;

    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.CompareTag("Player")) {
            if (gc.HasKey2) {
                gc.LoadScene("Torso");
            } else {
                Debug.Log("Player doesn't have key for door 2");
            }   
        }
    }
}
