using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LegsPickup : MonoBehaviour
{
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        gameObject.SetActive(gc.ShowLegs);
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Destroy(gameObject);
            gc.SwitchSceneAfterLegsPickup();
            gc.PlayerAnimator.SetBool("bodyidle", true);
        }
    }
}