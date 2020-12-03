using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform goal;

    void Start()
    {
        Spawn(5);
    }

    void FixedUpdate()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Spawn
    {
        Instantiate(prefab, transform.position, Quaternion.identity)
    }  
}