using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    public void FixedUpdate()
    {
        cam.transform.position = new Vector3(player.transform.position.x, 20, player.transform.position.z);
    }
}