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

        // if (Input.GetKey("space")) {
        //     Debug.Log("space key pressed");
        //     rb.AddForce(new Vector2(0.0f, 1.0f), ForceMode2D.Impulse);
        // }

        // if (Input.GetKeyDown(KeyCode.J)) {
        //     Debug.Log("j pressed");
        //     rb.AddForce(new Vector2(1.0f, 0.0f), ForceMode2D.Impulse);
        // }

    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);            
        }
        else
        {
            rb.gravityScale = 3f;
        }

        if (!isLadder) {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            rb.gravityScale = 3f;
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