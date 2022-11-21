using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Eyes Sprites
    public Sprite LeftEyesSprite;
    public Sprite RightEyesSprite;
    public Sprite IdleEyesSprite;

    // Head Sprites
    public Sprite LeftHeadSprite;
    public Sprite RightHeadSprite;
    public Sprite IdleHeadSprite;

    // Movement
    Vector2 movement;
    public float movement_speed = 5;
    private float moveHorizontal;
    private float moveVertical;

    private PlayerStateDevelopment psd;
    public MonoBehaviour LadderMovement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        psd = PlayerStateDevelopment.GetInstance()!;
        LadderMovement.enabled = false;
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
        PickSprite(movement.x);
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Eyes"){
            psd.ProgressPlayerState();
            Debug.Log("Should be changing to next scene");
            Debug.Log("Before change: " + transform.position);
            transform.position = new Vector2(5.07f, 0);
            Debug.Log("After change: " + transform.position);
            UnityEngine.Rendering.Universal.Light2D playerLight = this.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
            playerLight.pointLightOuterRadius += 10;
            playerLight.pointLightInnerRadius += 10;
            LadderMovement.enabled = true;
            this.enabled = false;
        } else if (other.gameObject.tag == "Arms") {
            psd.ProgressPlayerState();

        }
    }


    void PickSprite(float direction)
    {
        switch (psd.currPlayerState) {
            case PlayerStateDevelopment.PlayerState.Eyes:
                if (direction == 1)
                    spriteRenderer.sprite = RightEyesSprite;
                else if (direction == -1)
                    spriteRenderer.sprite = LeftEyesSprite;
                else
                    spriteRenderer.sprite = IdleEyesSprite;
                break;
            case PlayerStateDevelopment.PlayerState.Head:
                if (direction == 1)
                    spriteRenderer.sprite = RightHeadSprite;
                else if (direction == -1)
                    spriteRenderer.sprite = LeftHeadSprite;
                else
                    spriteRenderer.sprite = IdleHeadSprite;
                break;
            default:
                break;
        }
    }
}