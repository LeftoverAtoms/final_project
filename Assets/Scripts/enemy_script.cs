using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_script : MonoBehaviour
{
    private GameObject instantiate_enemy;
    public GameObject player;
    public GameObject enemy;

    //private NavMeshAgent agent;

    public float currentTime;
    public float spawn_rate = 1;

    public bool has_spawned;
    private bool round_end;

    void Start() //CALLED AT START
    {
        player = GameObject.FindWithTag("Player");
        //agent = enemy.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate() //UPDATES EVERY FRAME
    {
        EnemyAI(); //ENEMY AI
        EnemySpawn(); //ENEMY SPAWNER
    }

    //ENEMIES SPAWN WITHOUT CARING ABOUT CURRENTTIME

    void EnemySpawn()
    {
        if (Input.GetKey(KeyCode.Mouse1) && has_spawned == false)
        {
            instantiate_enemy = Instantiate(enemy, new Vector3(0, 0, 0), transform.rotation);
            has_spawned = true;
            Debug.Log("ENEMY SPAWNED");
        }

        if (has_spawned == true)
        {
            currentTime = currentTime + 1 * Time.deltaTime;
            if (currentTime > spawn_rate)
            {
                has_spawned = false;
                currentTime = 0;
            }
        }
    }

    //void RoundSystem() //ROUND LOGIC
    //{
    //    if (round_end)
    //    {
    //        enemy_count = enemy_count * 0.5f;
    //    }
    //}

    void EnemyAI() //ENEMY AI
    {
        //agent.destination = player.transform.position;
    }
}