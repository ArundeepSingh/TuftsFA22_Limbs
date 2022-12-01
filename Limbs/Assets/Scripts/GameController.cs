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
    

    void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementscript = myPlayer.GetComponent("PlayerMovement") as MonoBehaviour;
        LadderMovementscript = myPlayer.GetComponent("LadderMovement") as MonoBehaviour;
        LadderMovementscript.enabled = false;
        PlayerMovementscript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("StartScene");
    }

    public void SwitchSceneAfterEyesPickup() {
        SceneManager.LoadScene("UnlockAnimation");
    }

    public void LoadEyesScene() {
        SceneManager.LoadScene("EyesScene");
        LadderMovementscript.enabled = true;
        PlayerMovementscript.enabled = false;
    }
}
