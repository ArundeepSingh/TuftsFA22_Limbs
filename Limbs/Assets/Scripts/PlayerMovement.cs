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

    // Animation
    public Animator PlayerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.enabled = false;
        psd = PlayerStateDevelopment.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        // Left = -1, No keypress = 0, Right = 1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (psd.currPlayerState == PlayerStateDevelopment.PlayerState.Head) {
            if (movement.x == 1) PlayerAnimator.SetBool("right", true);
            else if (movement.x == -1) PlayerAnimator.SetBool("left", true);
            else if (movement.y == 1) PlayerAnimator.SetBool("up", true);
            else if (movement.y == -1) PlayerAnimator.SetBool("down", true);
            else {
                foreach(AnimatorControllerParameter parameter in PlayerAnimator.parameters) {            
                    PlayerAnimator.SetBool(parameter.name, false);            
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime);
        PickSprite(movement.x);
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Eyes"){
            Debug.Log("progressing player state from eyes");
            psd.ProgressPlayerState();
            PlayerAnimator.enabled = true;
            UnityEngine.Rendering.Universal.Light2D playerLight = this.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
            playerLight.pointLightOuterRadius += 10;
            playerLight.pointLightInnerRadius += 10;
        } else if (other.gameObject.tag == "Arms") {
            Debug.Log("Progressing player state from arms");
            psd.ProgressPlayerState();
        } else if (other.gameObject.tag == "Torso") {
            Debug.Log("Progressing to Torso");
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