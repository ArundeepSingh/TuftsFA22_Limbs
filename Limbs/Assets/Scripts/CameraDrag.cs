using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public GameObject player;
    public float camSpeed = 4.0f;
    public float max_x = 40f;
    public float pos_x;
    public float rate = 2;

    void Start() {
        pos_x = -16f;
    }

    void FixedUpdate()
    {   
        pos_x += rate * Time.fixedDeltaTime;
        Vector2 newpos = new Vector2 (pos_x, player.transform.position.y);
        Vector2 pos =   
                Vector2
                    .Lerp((Vector2) transform.position,
                    newpos,
                    camSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
