using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public float speed;

    public void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        player.transform.Translate(x * speed, 0, y * speed, Space.World);
        player.transform.LookAt(target.transform);
    }
}