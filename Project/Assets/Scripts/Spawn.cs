using UnityEngine;

namespace DOA
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] Global global;

        float totalEnemyCount = 10;
        int maxEnemyCount = 100;
        int actualEnemyCount;

        float waveLogicInitialize;
        float waveChangeTime;

        int randomSpawn;

        void Start()
        {
            global.determinedEnemyCount = totalEnemyCount;
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
                    global.instantiate_enemy = Instantiate(global.enemy, new Vector3(30, 0, 0), transform.rotation);
                }
                else if (randomSpawn == 1)
                {
                    global.instantiate_enemy = Instantiate(global.enemy, new Vector3(-30, 0, 0), transform.rotation);
                }
                else if (randomSpawn == 2)
                {
                    global.instantiate_enemy = Instantiate(global.enemy, new Vector3(0, 0, 30), transform.rotation);
                }
                else if (randomSpawn == 3)
                {
                    global.instantiate_enemy = Instantiate(global.enemy, new Vector3(0, 0, -30), transform.rotation);
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
            if (global.determinedEnemyCount <= 0)
            {
                waveChangeTime += Time.deltaTime;
            }

            if (waveChangeTime >= 5)
            {
                global.waveCount += 1;
                totalEnemyCount += 5;
                actualEnemyCount = 0;
                waveChangeTime = 0;
                global.determinedEnemyCount = totalEnemyCount;
            }
        }
    }
}