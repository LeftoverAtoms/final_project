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
        player.transform.LookAt(aim.transform);                             //Makes the player always look at the target
    }

    public void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");                              //Gets keyboard X input
        float y = Input.GetAxis("Vertical");                                //Gets keyboard Z input
        player.transform.Translate(x * speed, 0, y * speed, Space.World);   //Applies keyboard inputs
    }
}