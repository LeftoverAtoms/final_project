using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ui_script : MonoBehaviour
{
    public entity_spawn_script _entity_spawn_script;
    public global_variables _global_variables;

    public Text enemyCount;
    public Text score;

    void FixedUpdate()
    {
        enemyCount.text = "Enemies Spawned: " + _entity_spawn_script.currentEnemyCount;
        score.text = "Score: " + _global_variables.playerScore;
    }
}