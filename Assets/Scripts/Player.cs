using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject aim;
    public GameObject enemy;
    public ParticleSystem tracer;
    public float speed;

    public void FixedUpdate()
    {
        player.transform.LookAt(aim.transform);                                                    //Makes the player always look at the target

        float x = Input.GetAxis("Horizontal");                                                     //Gets keyboard X input
        float y = Input.GetAxis("Vertical");                                                       //Gets keyboard Z input
        player.transform.Translate(x * speed, 0, y * speed, Space.World);                          //Applies keyboard inputs

        LayerMask mask = LayerMask.GetMask("Enemy");

        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))
            {
                Destroy(hit.transform.gameObject);
            }
            tracer.Play();
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}