using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_script : MonoBehaviour
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
        agent.destination = player.transform.position;
    }
}