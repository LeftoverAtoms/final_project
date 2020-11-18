using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float speed;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;                //Gets keyboard x input
        float z = Input.GetAxis("Vertical") * Time.deltaTime;                  //Gets keyboard z input
        player.transform.Translate(x * speed, 0, z * speed);                   //Applies keyboard inputs to the player
        player.transform.LookAt(target.transform);                             //Player will always look at the target
    }
}
