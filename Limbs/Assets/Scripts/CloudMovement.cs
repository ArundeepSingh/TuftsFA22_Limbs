using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private GameObject player;
    private GameController gc;
    private float TimeBetweenDamage = 2f;
    private float DamageTimer = 0f;
    private bool CanHit = true;
    private float movement_speed;
    private float TimeBetweenIncrementSpeed = 5f;
    private float IncrementSpeedTimer = 0f;
    private float cur_pos_x;


    void Start() {
        player = GameObject.FindWithTag("Player");
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        movement_speed = 0.5f;
        cur_pos_x = player.transform.position.x - 105f;
    }

    void FixedUpdate()
    {   
        Debug.Log("movement speed: " + movement_speed);
        float change_pos_x = movement_speed * Time.deltaTime;
        cur_pos_x += change_pos_x;
        transform.position = new Vector3(cur_pos_x, transform.position.y, transform.position.z);

        IncrementSpeedTimer += Time.deltaTime;

        if (IncrementSpeedTimer >= TimeBetweenIncrementSpeed) {
            movement_speed += 0.5f;
            if (movement_speed >= 4f) movement_speed = 4f;
            IncrementSpeedTimer = 0;
        }

        if (!CanHit) {
            DamageTimer -= Time.deltaTime;
            if (DamageTimer <= 0f) {
                CanHit = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && CanHit){
            gc.Health -= 10;
            CanHit = false;
            DamageTimer = TimeBetweenDamage;
        }
    }
}

