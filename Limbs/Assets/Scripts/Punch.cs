using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    void Start() {
        Debug.Log("can punch");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("punched");
        }
    }
}
