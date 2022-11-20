// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraShake : MonoBehaviour
// {
//     public IEnumerator Shake(float duration, float magnitude) {
//         Vector3 original_pos = new Vector3(0, 0, 0);
//         float elapsed_time = 0f;

//         while (elapsed_time < duration) {
//             float x_offset = Random.Range(-0.5, 0.5) * magnitude;
//             float y_offset = Random.Range(-0.5, 0.5) * magnitude;

//             transform.localPosition = new Vector3(x_offset, y_offset, original_pos.z);

//             elapsed_time += Time.fixedDeltaTime;


//             yield return null;

//         }


//         transform.localPosition = original_pos;
//     }
// }