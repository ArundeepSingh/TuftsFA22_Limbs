using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDevelopment : MonoBehaviour
{
    private static PlayerStateDevelopment _instance;

    // Player state transformations
    public enum PlayerState
    {
        Eyes,
        Head,
        Arms,
        Torso,
        Legs
    }
    public PlayerState currPlayerState = PlayerState.Eyes;

    void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static PlayerStateDevelopment GetInstance()
    {
        if (_instance == null) {
            throw new System.Exception("PlayerStateDevelopment instance is null");
        } else {
            return _instance;
        }
    }

    void Start()
    {
        currPlayerState = PlayerState.Eyes;
    }

    public void ProgressPlayerState()
    {
        Debug.Log("Progressing player state");
        Debug.Log(currPlayerState);
        if (currPlayerState == PlayerState.Eyes){
            currPlayerState = PlayerState.Head;
        }
        else if (currPlayerState == PlayerState.Head){
            currPlayerState = PlayerState.Arms;
        }
        else if (currPlayerState == PlayerState.Arms){
            currPlayerState = PlayerState.Torso;
        }
        else if (currPlayerState == PlayerState.Torso){
            currPlayerState = PlayerState.Legs;
        }
    }
}
