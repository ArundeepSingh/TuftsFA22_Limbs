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
    private bool CoolDown = false;
    private float CoolDownTime = 1f;
    private float TimeBetweenJumps = 0f;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        TimeBetweenJumps += Time.deltaTime;

        if (TimeBetweenJumps > CoolDownTime) {
            CoolDown = false;
        }
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

        if (isLadder && horizontal == -1 && !CoolDown) {
            Debug.Log("shooting left");
            rb.AddForce(new Vector2(-7.5f, 10.0f), ForceMode2D.Impulse);
            isClimbing = false;
            CoolDown = true;
            TimeBetweenJumps = 0f;
        }   

        // Input.GetKeyDown(KeyCode.RightArrow)    
        if (isLadder && horizontal == 1 && !CoolDown) {
            Debug.Log("shooting right");
            rb.AddForce(new Vector2(7.5f, 10.0f), ForceMode2D.Impulse);
            isClimbing = false;
            CoolDown = true;
            TimeBetweenJumps = 0f;
        }  
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);         
        }

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
            Debug.Log(collision.transform.position);
            transform.position = new Vector3(collision.transform.position.x, transform.position.y, transform.position.z);
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