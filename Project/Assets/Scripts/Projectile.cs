using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace DOA
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] Global global;

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
            instantiate_projectile = Instantiate(projectile, global.player.transform.position, global.player.transform.rotation);
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
}