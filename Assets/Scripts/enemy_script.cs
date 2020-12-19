using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_script : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    public GameObject enemy;

    private float enemyHealth = 100;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = enemy.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        EnemyHealth();
        EnemyAI();
    }

    void EnemyHealth()
    {
        if (enemyHealth <= 0)
        {

        }
    }

    void EnemyAI()
    {
        agent.SetDestination(player.transform.position);
    }
}