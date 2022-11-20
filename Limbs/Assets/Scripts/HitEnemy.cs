using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public GameObject Camera;

    IEnumerator OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.tag == "Enemy"){
            yield return StartCoroutine(Camera.GetComponent<CameraShake>().Shake(1.0f, 0.25f));
        }
    }
}
