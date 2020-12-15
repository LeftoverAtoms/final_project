using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity_spawn_script : MonoBehaviour
{
    private GameObject instantiate_enemy;
    public GameObject enemy;

    public float currentEnemyCount;
    public float currentEnemyTotal;

    void FixedUpdate()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        Vector3 spawnPos = new Vector3(Random.Range(15, -15), 0, Random.Range(15, -15));
        if (currentEnemyCount < currentEnemyTotal)
        {
            instantiate_enemy = Instantiate(enemy, spawnPos, transform.rotation);
            currentEnemyCount++;
        }
    }
}