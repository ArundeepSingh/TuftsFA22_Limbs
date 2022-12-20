using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public GameObject Camera;

    private AudioSource audioSource;
    public AudioClip[] PlayerHurtAudioClips;

    private GameController gc;
    public bool GotHit;
    private PlayerStateDevelopment psd;
    
    
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        psd = PlayerStateDevelopment.GetInstance();
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            GotHit = true;
            if (psd.currPlayerState == PlayerStateDevelopment.PlayerState.Eyes) GotHit = false;
                audioSource.PlayOneShot(PlayerHurtAudioClips[Random.Range(0, PlayerHurtAudioClips.Length)]);
                yield return StartCoroutine(Camera.GetComponent<CameraShake>().Shake(1.0f, 0.25f));
        }
    }
    
}
