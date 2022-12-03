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
    private bool ShowEyes;
    private Vector3 PlayerPos;
    private MonoBehaviour CameraFollowscript;
    

    void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementscript = myPlayer.GetComponent("PlayerMovement") as MonoBehaviour;
        LadderMovementscript = myPlayer.GetComponent("LadderMovement") as MonoBehaviour;
        CameraFollowscript = Camera.main.GetComponent("CameraFollow2DLERP") as MonoBehaviour;
        LadderMovementscript.enabled = false;
        PlayerMovementscript.enabled = true;
        ShowEyes = true;
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
        PlayerPos = new Vector3(21f, -10f, 0f);
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
    }

    public void LoadArmsScene() {
        myPlayer.transform.position = new Vector3(15f, -14f, 0f);
        SceneManager.LoadScene("ArmsScene");
        LadderMovementscript.enabled = true;
        PlayerMovementscript.enabled = false;
    }
}
