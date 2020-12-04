using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject aim;
    public GameObject enemy;
    public GameObject projectile;
    public ParticleSystem Elimination;
    public float speed;

    void FixedUpdate()
    {
        player.transform.LookAt(aim.transform);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        player.transform.Translate(x * speed, 0, y * speed, Space.World);

        LayerMask mask = LayerMask.GetMask("Enemy");

        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Projectile();
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))
            {
                Destroy(hit.transform.gameObject);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void Projectile()
    {
        Instantiate(projectile, new Vector3(0, 0, 0), Quaternion.identity);
        //new Vector3(0, 0, 100);
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Enemy")
            Elimination.Play();
    }
}