using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject aim;
    public GameObject enemy;
    public ParticleSystem elimination;
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
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))
            {
                Destroy(hit.transform.gameObject);
                elimination.Play();
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}