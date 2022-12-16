using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private GameController gc;
    public int KeyNum;

    // Start is called before the first frame update
    void Start()
    {
        // get the game controller object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("collided with key");
            Destroy(gameObject);
            gc.HasKeys += 1;
        }
    }
}