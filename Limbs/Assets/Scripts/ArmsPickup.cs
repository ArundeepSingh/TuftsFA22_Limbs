using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsPickup : MonoBehaviour
{
    private GameController gc;
    public GameObject LadderColliders;

    // Start is called before the first frame update
    void Start()
    {
        // get the game controller object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        // show eyes if they are set to be shown
        gameObject.SetActive(gc.ShowArms);
        LadderColliders.SetActive(gc.CanClimb);
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Destroy(gameObject);
            gc.enableArmsAnim = true;
            LadderColliders.SetActive(true);
            gc.SwitchSceneAfterArmsPickup();
        }
    }
}
