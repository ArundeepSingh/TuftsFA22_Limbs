using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private GameObject player;
    private GameController gc;
    private float TimeBetweenDamage = 2f;
    private float Timer = 0f;
    private bool CanHit = true;

    void Start() {
        player = GameObject.FindWithTag("Player");
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void FixedUpdate()
    {   
        float pos_x = Camera.main.transform.position.x - 20f;
        transform.position = new Vector3(pos_x, transform.position.y, transform.position.z);

        if (!CanHit) {
            Timer -= Time.deltaTime;
            Debug.Log(Timer);
            if (Timer <= 0f) {
                CanHit = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && CanHit){
            gc.Health -= 10;
            CanHit = false;
            Timer = TimeBetweenDamage;
        }
    }
}

