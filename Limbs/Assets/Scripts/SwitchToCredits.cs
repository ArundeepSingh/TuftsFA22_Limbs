using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchToCredits : MonoBehaviour
{
    private MonoBehaviour CameraFollowscript;

    void Start() {
        CameraFollowscript.enabled = false;
    }

    public void SwitchToCreditsScene() {
        SceneManager.LoadScene("CreditsScene");
    }
}
