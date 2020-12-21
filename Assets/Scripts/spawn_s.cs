using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class spawn_s : MonoBehaviour
{
    public global_s global_s;

    private float totalEnemyCount = 10;
    private int maxEnemyCount = 100;
    private int actualEnemyCount;

    private float waveLogicInitialize;
    private float waveChangeTime;

    private int randomSpawn;

    void Start()
    {
        global_s.determinedEnemyCount = totalEnemyCount;
    }

    void FixedUpdate()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        if (actualEnemyCount >= maxEnemyCount)
        {
        }
        else if (actualEnemyCount < totalEnemyCount)
        {
            actualEnemyCount += 1;

            randomSpawn = Random.Range(0, 4);

            if (randomSpawn == 0)
            {
                global_s.instantiate_enemy = Instantiate(global_s.enemy, new Vector3(30, 0, 0), transform.rotation);
            }
            else if (randomSpawn == 1)
            {
                global_s.instantiate_enemy = Instantiate(global_s.enemy, new Vector3(-30, 0, 0), transform.rotation);
            }
            else if (randomSpawn == 2)
            {
                global_s.instantiate_enemy = Instantiate(global_s.enemy, new Vector3(0, 0, 30), transform.rotation);
            }
            else if (randomSpawn == 3)
            {
                global_s.instantiate_enemy = Instantiate(global_s.enemy, new Vector3(0, 0, -30), transform.rotation);
            }

        }

        if (actualEnemyCount <= totalEnemyCount)
        {
            waveLogicInitialize += Time.deltaTime;

            if (waveLogicInitialize >= 1)
            {
                waveLogicInitialize = 1;
                WaveLogic();
            }
        }
    }

    void WaveLogic()
    {
        if (global_s.determinedEnemyCount <= 0)
        {
            waveChangeTime += Time.deltaTime;
        }

        if (waveChangeTime >= 5)
        {
            global_s.waveCount += 1;
            totalEnemyCount += 5;
            actualEnemyCount = 0;
            waveChangeTime = 0;
            global_s.determinedEnemyCount = totalEnemyCount;
        }
    }
}