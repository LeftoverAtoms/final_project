using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class projectile_s : MonoBehaviour
{
    public global_s global_s;

    public GameObject instantiate_projectile;
    public Rigidbody projectile_rb;
    public GameObject projectile;

    void Start()
    {
        projectile_rb = projectile.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        projectile_rb.AddForce(projectile.transform.forward * 100, ForceMode.Impulse);
    }

    public void ProjectilePrefab()
    {
        instantiate_projectile = Instantiate(projectile, global_s.player.transform.position, global_s.player.transform.rotation);
        Destroy(instantiate_projectile, 1.5f);
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "enemy" | Collision.gameObject.tag == "level")
        {
            Destroy(instantiate_projectile);
        }
    }
}