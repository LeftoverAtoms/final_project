using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity_spawn_script : MonoBehaviour
{
    private float milestoneEnemyCounter;
    private float currentEnemyLimit = 5;
    public float currentEnemyCount;

    public GameObject instantiate_enemy;
    public GameObject ammoBox;
    public GameObject enemy;

    private int randomSpawn;

    void FixedUpdate()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        if (currentEnemyCount < currentEnemyLimit)                                                                     //If the current amount of enemies exceeds the max enemies then nothing happens until more room is available.
        {
            randomSpawn = Random.Range(0, 4);
            milestoneEnemyCounter++;
            currentEnemyCount++;
            if (randomSpawn == 0)
            {
                instantiate_enemy = Instantiate(enemy, new Vector3(30, 0, 0), transform.rotation);
            }
            else if (randomSpawn == 1)
            {
                instantiate_enemy = Instantiate(enemy, new Vector3(-30, 0, 0), transform.rotation);
            }
            else if (randomSpawn == 2)
            {
                instantiate_enemy = Instantiate(enemy, new Vector3(0, 0, 30), transform.rotation);
            }
            else if (randomSpawn == 3)
            {
                instantiate_enemy = Instantiate(enemy, new Vector3(0, 0, -30), transform.rotation);
            }
        }
        else
        {

        }

        if (milestoneEnemyCounter == 5)
        {
            Instantiate(ammoBox, new Vector3(0, 0, 0), transform.rotation);
            currentEnemyLimit = currentEnemyLimit + 5;
            milestoneEnemyCounter = 0;
        }
    }
}