using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public GameObject Camera;
    public AudioSource[] Sounds;
    private GameController gc;
    public bool GotHit;
    private PlayerStateDevelopment psd;
    
    
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        psd = PlayerStateDevelopment.GetInstance();
    }

    IEnumerator OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            Sounds[Random.Range(0, Sounds.Length)].Play();
            GotHit = true;
            if (psd.currPlayerState == PlayerStateDevelopment.PlayerState.Eyes) GotHit = false;
            yield return StartCoroutine(Camera.GetComponent<CameraShake>().Shake(1.0f, 0.25f));
        }
    }
    
}
