using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject myPlayer;
    private MonoBehaviour PlayerMovementscript;
    private MonoBehaviour LadderMovementscript;
    public Vector3 PlayerPos;
    private MonoBehaviour CameraFollowscript;
    private Rigidbody2D rb;
    public Canvas canvas;
    public GameObject MenuGraphics;
    public bool ShowDoor1;
    public bool ShowTorso;
    public bool ShowEyes;
    public bool HasKey2;
    public bool ShowArms;
    public int CurHealth;
    public int MaxHealth;
    public bool CanClimb;
    private Animator PlayerAnimator;
    private GameObject HealthBar;

    void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementscript = myPlayer.GetComponent("PlayerMovement") as MonoBehaviour;
        LadderMovementscript = myPlayer.GetComponent("LadderMovement") as MonoBehaviour;
        CameraFollowscript = Camera.main.GetComponent("CameraFollow2DLERP") as MonoBehaviour;
        rb = myPlayer.GetComponent<Rigidbody2D>();
        PlayerAnimator = myPlayer.GetComponent<Animator>();
        LadderMovementscript.enabled = false;
        PlayerMovementscript.enabled = true;
        ShowEyes = true;
        ShowDoor1 = false;
        HasKey2 = false;
        ShowTorso = true;
        ShowArms = true;
        MaxHealth = 100;
        CurHealth = 100;
        CanClimb = false;
        DontDestroyOnLoad(Camera.main);
    }

    public void StartGame() {
        // POSITION FOR TESTING
        PlayerPos = new Vector3(-14.5f, -5f, 0f);
        // POSITION FOR FINAL GAME
        //PlayerPos = new Vector3(20f, -7.5f, 0f);
        Destroy(MenuGraphics);
        LoadScene("Start");
    }

    public void SwitchSceneAfterEyesPickup() {
        PlayerPos = myPlayer.transform.position;
        Debug.Log(PlayerPos);
        SceneManager.LoadScene("UnlockAnimationEyes");
        myPlayer.gameObject.SetActive(false);
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        CameraFollowscript.enabled = false;
        Debug.Log("going to unlock animation, setting eyes to false");
        ShowEyes = false;
        ShowDoor1 = true;
    }

    public void SwitchSceneAfterArmsPickup() {
        PlayerPos = myPlayer.transform.position;
        Debug.Log(PlayerPos);
        SceneManager.LoadScene("UnlockAnimationArms");
        myPlayer.gameObject.SetActive(false);
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        CameraFollowscript.enabled = false;
        ShowArms = false;
        CanClimb = true;
    }

    public void SwitchSceneAfterTorsoPickup() {
        PlayerPos = myPlayer.transform.position;
        SceneManager.LoadScene("UnlockAnimationTorso");
        myPlayer.gameObject.SetActive(false);
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        CameraFollowscript.enabled = false;
        ShowTorso = false;
    }

    public void LoadScene(string ToLoad) {
        myPlayer.gameObject.SetActive(true);
        myPlayer.transform.position = PlayerPos;
        CameraFollowscript.enabled = true;
        Vector3 CameraPos = PlayerPos;
        CameraPos.z = -10;
        Camera.main.transform.position = CameraPos;
        switch(ToLoad) 
            {
            case "Start":
                SceneManager.LoadScene("StartScene");
                break;
            case "Arms":
                SceneManager.LoadScene("ArmsScene");
                LadderMovementscript.enabled = true;
                PlayerMovementscript.enabled = false;
                foreach(AnimatorControllerParameter parameter in PlayerAnimator.parameters) {            
                    PlayerAnimator.SetBool(parameter.name, false);            
                }
                break;
            case "Torso":
                SceneManager.LoadScene("TorsoScene");
                LadderMovementscript.enabled = false;
                PlayerMovementscript.enabled = true;
                myPlayer.transform.position = new Vector3(0f, 0f, 0f);
                rb.gravityScale = 0f;
                break;
            default:
                break;
            }
        HealthBar = GameObject.Find("HealthBar");
    }    
}
