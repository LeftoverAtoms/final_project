using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity_spawn_script : MonoBehaviour
{
    private GameObject instantiate_enemy;
    public GameObject enemy;

    private float enemyCurrentTime;
    public float enemySpawnRate;
    public float enemyCount;
    public float enemyMax = 5;

    private bool enemyHasSpawned;
    public bool roundEnd;

    void FixedUpdate()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        if (enemyCount <= enemyMax)
        {
            if (enemyHasSpawned == false)
            {
                instantiate_enemy = Instantiate(enemy, new Vector3(0, 0, 0), transform.rotation);
                enemyHasSpawned = true;
                enemyCount = enemyCount + 1;
                Debug.Log("ENEMY SPAWNED");
            }

            if (enemyHasSpawned == true)
            {
                enemyCurrentTime = enemyCurrentTime + 1 * Time.deltaTime;
                if (enemyCurrentTime > enemySpawnRate)
                {
                    enemyHasSpawned = false;
                    enemyCurrentTime = 0;
                }
            }
        }
        else if (enemyCount >= enemyMax)
        {
            return;
        }
    }
}