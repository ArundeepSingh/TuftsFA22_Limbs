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
    private MonoBehaviour CameraFollowscript;
    private MonoBehaviour CameraDragScript;
    public Vector3 PlayerPos;
    private Rigidbody2D rb;
    public Canvas canvas;
    public GameObject MenuGraphics;
    public bool ShowDoor1, ShowTorso;
    public bool ShowEyes;
    public bool HasKey2;
    public bool ShowArms;
    public bool CanClimb;
    public Animator PlayerAnimator;
    public float Health;
    public float MaxHealth = 100f;
    public float BossHealth;
    public float BossMaxHealth = 200f;
    public bool enableArmsAnim;
    public bool BleedingOut;
    public string LastScene;
    public int HasKeys;

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
        CameraDragScript = Camera.main.GetComponent("CameraDrag") as MonoBehaviour;
        rb = myPlayer.GetComponent<Rigidbody2D>();
        PlayerAnimator = myPlayer.GetComponent<Animator>();
        PlayerAnimator.keepAnimatorControllerStateOnDisable = true;
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
        Health = MaxHealth; 
        BossHealth = BossMaxHealth; // MAX HEALTH
        HasKeys = 0;
        DontDestroyOnLoad(Camera.main);
    }

    public void StartGame() {
        // POSITION FOR TESTING
        //PlayerPos = new Vector3(-14.5f, -3f, 0f);
        // POSITION FOR FINAL GAME
        PlayerPos = new Vector3(20f, -7.5f, 0f);
        LoadScene("StartScene");
    }

    public void SwitchSceneAfterEyesPickup() {
        PlayerPos = myPlayer.transform.position;
        Debug.Log(PlayerPos);
        SceneManager.LoadScene("UnlockAnimationEyes");
        myPlayer.gameObject.SetActive(false);
        Debug.Log("my player is active?");
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
        // PlayerAnimator.SetBool("armwalk", true);
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
            case "StartScene":
                SceneManager.LoadScene("StartScene");
                break;
            case "ArmsScene":
                SceneManager.LoadScene("ArmsScene");
                LadderMovementscript.enabled = true;
                PlayerMovementscript.enabled = false;
                // LINE BELOW STARTS ARMWALK ANIMATION RIGHT WHEN SCENE LOADS
                // PlayerAnimator.SetBool("armwalk", enableArmsAnim);
                // foreach(AnimatorControllerParameter parameter in PlayerAnimator.parameters) {            
                //     PlayerAnimator.SetBool(parameter.name, false);            
                // }
                break;
            case "TorsoScene":
                SceneManager.LoadScene("TorsoScene");
                LadderMovementscript.enabled = false;
                PlayerMovementscript.enabled = true;
                myPlayer.transform.position = new Vector3(-15f, -20f, 0f);
                rb.gravityScale = 0f;
                break;
            case "LegsScene":
                BleedingOut = false;
                SceneManager.LoadScene("LegsScene");
                myPlayer.transform.position = new Vector3(-13f, -27f, 0f);
                break;
            case "BossScene":
                myPlayer.transform.position = new Vector3(0f, -13f, 0f);
                SceneManager.LoadScene("BossScene");
                break;
            case "LoseScene":
                SceneManager.LoadScene("LoseScene");
                break;
            default:
                break;
            }
    }
}
