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
    public string sceneToLoad;

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
        if (total_time > 5f) {
            new_part.SetActive(false);
            old_sprite.SetActive(false);
            new_sprite.SetActive(true);
        }

        if (total_time > 5f && total_time < 5.2f) {
            BigLight.intensity += 10f;
        }
        
        if (total_time > 5.5f && BigLight.intensity > 1f) {
            BigLight.intensity -= 2f;
        }
        
        // 8 SECONDS FOR FINAL PUSH, 1 SECOND FOR TESTING
        if (total_time > 7f) {
            gc.LoadScene(sceneToLoad);
        }
    }
}
