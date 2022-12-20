using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private GameController gc;
    public int KeyNum;
    public AudioClip keyPickupAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        // get the game controller object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        // only show key if they don't have it
        gameObject.SetActive(gc.HasKeys < KeyNum);
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("collided with key");

            AudioSource.PlayClipAtPoint(keyPickupAudioClip, this.gameObject.transform.position);

            Destroy(gameObject);
            gc.HasKeys = KeyNum;
        }
    }
}