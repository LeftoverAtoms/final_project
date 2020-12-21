using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class camera_s : MonoBehaviour
{
    public global_s global_s;

    public void FixedUpdate()
    {
        global_s.cam.transform.position = new Vector3(global_s.player.transform.position.x, 25, global_s.player.transform.position.z);
    }
}