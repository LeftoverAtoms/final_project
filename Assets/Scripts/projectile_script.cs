using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_script : MonoBehaviour
{
    public global_script global_script;

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
        instantiate_projectile = Instantiate(projectile, global_script.player.transform.position, global_script.player.transform.rotation);
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