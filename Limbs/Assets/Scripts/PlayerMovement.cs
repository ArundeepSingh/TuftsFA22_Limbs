using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite LeftSprite;
    public Sprite RightSprite;
    public Sprite IdleSprite;

    public float movement_speed = 5;
    private float moveHorizontal;
    private float moveVertical;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      // Left = -1, No keypress = 0, Right = 1
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");
      
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime);
        if (movement.x == 1) {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = RightSprite;
          Debug.Log("moving to right sprite");
        } else if (movement.x == -1) {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = LeftSprite;
        } else {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = IdleSprite;
        }
        
    }
}