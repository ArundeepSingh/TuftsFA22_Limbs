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
    private Vector3 PlayerPos;
    private MonoBehaviour CameraFollowscript;
    private Rigidbody2D rb;
    public bool ShowDoor1;
    private bool ShowEyes;
    public bool HasKey2;
    

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
        LadderMovementscript.enabled = false;
        PlayerMovementscript.enabled = true;
        ShowEyes = true;
        ShowDoor1 = false;
        HasKey2 = false;
        DontDestroyOnLoad(Camera.main);
    }

    // getters
    public bool GetShowEyes() {
        return ShowEyes;
    }

    public void SetShowEyes(bool ToSet) {
        ShowEyes = ToSet;
    }

    public void LoadStartScene() {
        SceneManager.LoadScene("StartScene");
        myPlayer.transform.position = PlayerPos;
        myPlayer.gameObject.SetActive(true);
        CameraFollowscript.enabled = true;
    }

    public void StartGame() {
        // PlayerPos = new Vector3(21f, -10f, 0f);
        PlayerPos = new Vector3(-14.5f, -8f, 0f);
        LoadStartScene();
    }

    public void SwitchSceneAfterEyesPickup() {
        PlayerPos = myPlayer.transform.position;
        Debug.Log(PlayerPos);
        SceneManager.LoadScene("UnlockAnimation");
        myPlayer.gameObject.SetActive(false);
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        CameraFollowscript.enabled = false;
        Debug.Log("going to unlock animation, setting eyes to false");
        ShowEyes = false;
        ShowDoor1 = true;
    }

    public void LoadArmsScene() {
        myPlayer.transform.position = new Vector3(15f, -14f, 0f);
        SceneManager.LoadScene("ArmsScene");
        LadderMovementscript.enabled = true;
        PlayerMovementscript.enabled = false;
    }

    public void LoadTorsoScene() {
        SceneManager.LoadScene("TorsoScene");
        LadderMovementscript.enabled = false;
        PlayerMovementscript.enabled = true;
        myPlayer.transform.position = new Vector3(0f, 0f, 0f);
        rb.gravityScale = 0f;
    }
}
