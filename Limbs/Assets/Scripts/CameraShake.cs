using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude) {

        Debug.Log("shakin");
        Vector3 original_pos = transform.position;
        float elapsed_time = 0f;

        while (elapsed_time < duration) {
            // Debug.Log("in while");
            float x_offset = Random.Range(-0.5f, 0.5f) * magnitude;
            float y_offset = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.position = new Vector3(original_pos.x + x_offset, original_pos.y +  y_offset, original_pos.z);

            // Debug.Log("x: " + transform.localPosition.x);
            // Debug.Log("y: " + transform.localPosition.y);

            elapsed_time += Time.fixedDeltaTime;
            yield return null;
        }

        // transform.localPosition = original_pos;

        Vector2 pos =
            Vector2
                .Lerp((Vector2) transform.position,
                (Vector2) GameObject.FindWithTag("Player").transform.position,
                4 * Time.fixedDeltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}