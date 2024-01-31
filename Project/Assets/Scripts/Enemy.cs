using UnityEngine;
using UnityEngine.AI;

namespace DOA
{
    public class Enemy : MonoBehaviour
    {
        public GameObject enemy;

        NavMeshAgent agent;
        GameObject player;

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
}