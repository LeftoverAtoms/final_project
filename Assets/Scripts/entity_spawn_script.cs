using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity_spawn_script : MonoBehaviour
{
    public GameObject instantiate_enemy;
    public GameObject enemy;

    public float milestoneEnemyCounter;
    public float currentEnemyCount;
    public float currentEnemyLimit = 5;

    void FixedUpdate()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        if (currentEnemyCount < currentEnemyLimit)                                                                     //If the current amount of enemies exceeds the max enemies then nothing happens until more room is available.
        {
            instantiate_enemy = Instantiate(enemy, new Vector3(0, 0, 20), transform.rotation);
            milestoneEnemyCounter++;
            currentEnemyCount++;
        }
        else
        {
            return;
        }

        if (milestoneEnemyCounter > 10)
        {
            currentEnemyLimit = currentEnemyLimit + 2;
            milestoneEnemyCounter = 0;
        }
    }
}