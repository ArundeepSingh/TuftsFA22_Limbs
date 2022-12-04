using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey2 : MonoBehaviour
{
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        // get the game controller object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        // show eyes if they are set to be shown
        door.SetActive(gc.ShowDoor1);
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Destroy(gameObject);
            gc.SwitchSceneAfterEyesPickup();
        }
    }
}
