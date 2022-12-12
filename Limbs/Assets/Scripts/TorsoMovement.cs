using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorsoMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Movement
    Vector2 movement;
    public float movement_speed = 5;
    private float moveHorizontal;
    private float moveVertical;

    private PlayerStateDevelopment psd;

    // Animation
    public Animator PlayerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
        psd = PlayerStateDevelopment.GetInstance();
        psd.ProgressPlayerState();
        psd.ProgressPlayerState();
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
    }

    public void OnTriggerEnter2D (Collider2D other){
        
    }

}