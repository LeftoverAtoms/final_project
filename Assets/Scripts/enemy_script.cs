using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_script : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private NavMeshAgent agent;

    void Start() //CALLED AT START
    {
        player = GameObject.FindWithTag("Player");
        agent = enemy.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate() //UPDATES EVERY FRAME
    {
        agent.destination = player.transform.position;
    }
}