using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackControl : MonoBehaviour
{   
    private float TimeToSwitch = 5f;
    public MonoBehaviour ShootingScript;
    public MonoBehaviour MeleeScript;

    void Start() {
        MeleeScript.enabled = true;
        ShootingScript.enabled = false;
    }

    void FixedUpdate() {
        TimeToSwitch -= Time.deltaTime;
        Debug.Log(TimeToSwitch);
        if (TimeToSwitch <= 0) {
            MeleeScript.enabled = !(MeleeScript.enabled);
            ShootingScript.enabled = !(ShootingScript.enabled);
            TimeToSwitch = 5f;
        }
    }
}
