using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_prefab_script : MonoBehaviour
{
    private GameObject player;
    public GameObject projectile;
    private GameObject instantiate_projectile;
    public Rigidbody projectile_rb;

    void Start() //CALLED AT START
    {
        player = GameObject.FindWithTag("Player");
        projectile_rb = projectile.GetComponent<Rigidbody>();
    }

    void FixedUpdate() //UPDATES EVERY FRAME
    {
        projectile_rb.AddForce(transform.forward * 100, ForceMode.Impulse);
        projectile_rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void Projectile_Prefab_Spawn() //SPAWNS PREFAB
    {
        instantiate_projectile = Instantiate(projectile, player.transform.position, player.transform.rotation);
        Destroy(instantiate_projectile, 1.5f);
    }

    void OnCollisionEnter(Collision Collision) //COLLISION DETECTION
    {
        if (Collision.gameObject.tag == "geometry" | Collision.gameObject.tag == "enemy")
        {
            Destroy(projectile);
            Debug.Log("DETECTED_COLLISION");
        }
    }
}