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
    private MonoBehaviour PlayerAttackScript;
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
    public bool CanClimb;
    private Animator PlayerAnimator;
    public float Health;
    public float MaxHealth = 100f;
    public bool enableArmsAnim;
    public bool BleedingOut;

    void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementscript = myPlayer.GetComponent("PlayerMovement") as MonoBehaviour;
        LadderMovementscript = myPlayer.GetComponent("LadderMovement") as MonoBehaviour;
        CameraFollowscript = Camera.main.GetComponent("CameraFollow2DLERP") as MonoBehaviour;
        PlayerAttackScript = myPlayer.GetComponent("MeleePlayerAttack") as MonoBehaviour;
        rb = myPlayer.GetComponent<Rigidbody2D>();
        PlayerAnimator = myPlayer.GetComponent<Animator>();
        LadderMovementscript.enabled = false;
        PlayerMovementscript.enabled = true;
        PlayerAttackScript.enabled = false;
        ShowEyes = true;
        ShowDoor1 = false;
        HasKey2 = false;
        ShowTorso = true;
        ShowArms = true;
        CanClimb = false;
        enableArmsAnim = false;
        BleedingOut = false;
        Health = MaxHealth; // MAX HEALTH
        DontDestroyOnLoad(Camera.main);
    }

    public void StartGame() {
        // POSITION FOR TESTING
        PlayerPos = new Vector3(-14.5f, -3f, 0f);
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
        PlayerAnimator.SetBool("armwalk", true);
    }

    public void SwitchSceneAfterTorsoPickup() {
        PlayerPos = myPlayer.transform.position;
        SceneManager.LoadScene("UnlockAnimationTorso");
        myPlayer.gameObject.SetActive(false);
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        CameraFollowscript.enabled = false;
        ShowTorso = false;
        PlayerAttackScript.enabled = true;
        BleedingOut = true;
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
                // LINE BELOW STARTS ARMWALK ANIMATION RIGHT WHEN SCENE LOADS
                PlayerAnimator.SetBool("armwalk", enableArmsAnim);
                // foreach(AnimatorControllerParameter parameter in PlayerAnimator.parameters) {            
                //     PlayerAnimator.SetBool(parameter.name, false);            
                // }
                break;
            case "Torso":
                SceneManager.LoadScene("TorsoScene");
                LadderMovementscript.enabled = false;
                PlayerMovementscript.enabled = true;
                myPlayer.transform.position = new Vector3(-15f, -20f, 0f);
                rb.gravityScale = 0f;
                break;
            case "Legs":
                SceneManager.LoadScene("LegsScene");
                break;
            case "Boss":
                SceneManager.LoadScene("BossScene");
                break;
            default:
                break;
            }
    }
}
