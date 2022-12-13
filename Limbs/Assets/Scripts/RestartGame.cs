using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RestartGame : MonoBehaviour
{
    private string SceneToLoad;
    private GameController gc;

    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        SceneToLoad = gc.LastScene;
    }

    public void Restart() {
        Debug.Log("SceneToLoad" + SceneToLoad);
        gc.Health = gc.MaxHealth;
        gc.LoadScene(SceneToLoad);
    }
}
