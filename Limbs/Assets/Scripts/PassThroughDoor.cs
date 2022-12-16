using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassThroughDoor : MonoBehaviour
{
    private GameController gc;
    public GameObject NoKeyDialogue;
    public int DoorNum;
    public string NextScene;
    public Vector3 NewPlayerPos;

    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.CompareTag("Player")) {
            if (gc.HasKeys >= DoorNum) {
                gc.PlayerPos = NewPlayerPos;
                gc.LoadScene(NextScene);
            } else {
                Debug.Log("Player doesn't have key number " + DoorNum);
                NoKeyDialogue.SetActive(true);
            }   
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        NoKeyDialogue.SetActive(false);        
    }
}
