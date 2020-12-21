using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class enemy_s : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    public GameObject enemy;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = enemy.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        EnemyAI();
    }

    void EnemyAI()
    {
        agent.SetDestination(player.transform.position);
    }
}