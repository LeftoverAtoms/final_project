using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_script : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private float currentTime;
    private float enemy_count;
    private float enemy_max = 24;
    public float spawn_rate;

    private bool has_spawned;
    private bool round_end;

    void Start() //CALLED AT START
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate() //UPDATES EVERY FRAME
    {
        EnemyAI(); //ENEMY AI
        EnemySpawn(); //ENEMY SPAWNER
    }

    public void EnemySpawn()
    {

       if (enemy_count >= enemy_max)
        {
            return;
        }

        if (has_spawned == false)
        {
            Instantiate(enemy);
            has_spawned = true;
            enemy_count += +1;
        }

        if (has_spawned)
        {
            currentTime = currentTime + 1 * Time.deltaTime;
            if (currentTime > spawn_rate)
            {
                has_spawned = false;
                currentTime = 0;
            }
        }
    }

    void RoundSystem() //ROUND LOGIC
    {
        if (round_end)
        {
            enemy_count = enemy_count * 0.5f;
        }
    }

    void EnemyAI() //ENEMY AI
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
    }
}