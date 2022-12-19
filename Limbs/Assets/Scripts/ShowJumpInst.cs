using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowJumpInst : MonoBehaviour
{
    private GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        // only show instruciton if they have arms
        gameObject.SetActive(!gc.ShowArms);
    }

}
