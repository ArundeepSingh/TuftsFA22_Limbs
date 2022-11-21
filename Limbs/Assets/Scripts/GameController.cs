using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("StartScene");
    }

    public void SwitchSceneAfterEyesPickup() {
        // display the achievement
        Image achievement = GameObject.Find("EyesAchievementUnlocked").GetComponent<Image>();
        achievement.enabled = true;
        
        StartCoroutine(WaitForAchievement(() => {
            SceneManager.LoadScene("EyesScene");
        }));
    }

    IEnumerator WaitForAchievement(System.Action callback) {
        yield return new WaitForSeconds(3);
        callback();
    }
}
