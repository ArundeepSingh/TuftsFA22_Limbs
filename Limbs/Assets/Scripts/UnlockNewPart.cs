using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockNewPart : MonoBehaviour
{
    public GameObject old_sprite;
    public GameObject new_part;
    public GameObject new_sprite;
    public UnityEngine.Rendering.Universal.Light2D BigLight;

    private float total_time = 0; 
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        new_sprite.SetActive(false);
    }

    private void FixedUpdate() {
        total_time += Time.deltaTime;
        if (total_time > 10f) {
            new_part.SetActive(false);
            old_sprite.SetActive(false);
            new_sprite.SetActive(true);
        }

        if (total_time > 10f && total_time < 10.2f) {
            BigLight.intensity += 30f;
        }
        
        if (total_time > 10.5f && BigLight.intensity > 1f) {
            BigLight.intensity -= 2f;
        }
        

        // SHOULD BE 11 SECONDS, CHANGE LATER
        if (total_time > 1f) {
            // load start scene again
            gc.LoadStartScene();
        }
    }
}
