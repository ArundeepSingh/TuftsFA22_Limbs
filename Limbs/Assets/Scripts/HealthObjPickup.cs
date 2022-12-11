using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObjPickup : MonoBehaviour
{
   private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        // get the game controller object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Destroy(gameObject);
            gc.Health += 10;
        }
    }
}
