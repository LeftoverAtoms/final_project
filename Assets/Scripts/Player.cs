using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject aim;
    public float speed;

    public void Update()
    {
        player.transform.LookAt(aim.transform);
    }

    public void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        player.transform.Translate(x * speed, 0, y * speed, Space.World);
    }
}