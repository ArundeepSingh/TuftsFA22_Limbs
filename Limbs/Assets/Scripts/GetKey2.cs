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
    }

    public void OnTriggerEnter2D (Collider2D other) {
        Debug.Log("key collided with something");
        if (other.gameObject.tag == "Player"){
            Debug.Log("collided with key");
            Destroy(gameObject);
            gc.HasKey2 = true;
        }
    }
}