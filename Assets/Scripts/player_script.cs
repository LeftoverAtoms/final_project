using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public projectile_prefab_script _projectile_prefab_script;
    public entity_spawn_script _entity_spawn_script;

    public GameObject player;
    public GameObject aim;
    public GameObject enemy;

    public float speed;

    private float currentTime;
    private bool has_shot;
    public float rof;

    void FixedUpdate()
    {
        ProjectileLogic();
        PlayerController();
    }

    void ProjectileLogic()
    {
        LayerMask mask = LayerMask.GetMask("enemy");
        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse0) && has_shot == false)
        {
            _projectile_prefab_script.Projectile_Prefab_Spawn();

            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))
            {
                Destroy(hit.transform.gameObject);
                _entity_spawn_script.currentEnemyCount--;
                Debug.Log("DAMGE_ENEMY");
            }
            has_shot = true;
        }

        if (has_shot)
        {
            currentTime = currentTime + 1 * Time.deltaTime;
            if (currentTime > rof)
            {
                has_shot = false;
                currentTime = 0;
            }
        }
    }

    void PlayerController()
    {
        player.transform.LookAt(aim.transform);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        player.transform.Translate(x * speed, 0, y * speed, Space.World);
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "enemy")
        {
            Debug.Log("DAMAGE_PLAYER");
        }
    }
}