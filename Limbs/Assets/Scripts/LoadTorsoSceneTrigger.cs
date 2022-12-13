using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTorsoSceneTrigger : MonoBehaviour
{
    private GameController gc;
    public GameObject NoKeyDialogue;

    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.CompareTag("Player")) {
            if (gc.HasKey2) {
                gc.LoadScene("TorsoScene");
            } else {
                Debug.Log("Player doesn't have key for door 2");
                NoKeyDialogue.SetActive(true);
            }   
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        NoKeyDialogue.SetActive(false);        
    }
}
