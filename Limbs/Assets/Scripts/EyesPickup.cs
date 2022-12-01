using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EyesPickup : MonoBehaviour
{
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        // get the game controller object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("Destroying eyes hopefully");
            Destroy(gameObject);
            gc.SwitchSceneAfterEyesPickup();
        }
    }
}
