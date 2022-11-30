using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    public float speed = 7f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

        if (isLadder && Input.GetKeyDown(KeyCode.J)) {
            Debug.Log("shooting left");
            rb.AddForce(new Vector2(-15.0f, 20.0f), ForceMode2D.Impulse);
            isClimbing = false;
        }   

        if (isLadder && Input.GetKeyDown(KeyCode.K)) {
            Debug.Log("shooting right");
            rb.AddForce(new Vector2(15.0f, 20.0f), ForceMode2D.Impulse);
            isClimbing = false;
        }  

    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);         
        }
        // else
        // {
        //     rb.gravityScale = 3f;
        // }

         

        if (!isLadder) {
            if (horizontal != 0) {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            rb.gravityScale = 3f;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            isLadder = true;
            Debug.Log("entered ladder");
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}