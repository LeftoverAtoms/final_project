using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity_spawn_script : MonoBehaviour
{
    public global_script global_script;

    private int currentEnemyTotal = 5;
    private int maxEnemyCount = 100;
    public int milestoneEnemyCount;
    public int currentEnemyCount;

    public GameObject instantiate_enemy;

    private int randomSpawn;

    void FixedUpdate()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        if (currentEnemyCount == maxEnemyCount)
        {
            return;
        }
        else if (currentEnemyCount < currentEnemyTotal)
        {
            randomSpawn = Random.Range(0, 4);
            currentEnemyCount++;
            if (randomSpawn == 0)
            {
                instantiate_enemy = Instantiate(global_script.enemy, new Vector3(30, 0, 0), transform.rotation);
            }
            else if (randomSpawn == 1)
            {
                instantiate_enemy = Instantiate(global_script.enemy, new Vector3(-30, 0, 0), transform.rotation);
            }
            else if (randomSpawn == 2)
            {
                instantiate_enemy = Instantiate(global_script.enemy, new Vector3(0, 0, 30), transform.rotation);
            }
            else if (randomSpawn == 3)
            {
                instantiate_enemy = Instantiate(global_script.enemy, new Vector3(0, 0, -30), transform.rotation);
            }
        }

        if (currentEnemyCount == maxEnemyCount)
        {
            return;
        }
        else if (milestoneEnemyCount == 10)
        {
            milestoneEnemyCount = 0;
            currentEnemyTotal += 5;
        }
    }
}