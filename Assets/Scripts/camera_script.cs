using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    public void FixedUpdate()
    {
        cam.transform.position = new Vector3(player.transform.position.x, 25, player.transform.position.z);
    }
}