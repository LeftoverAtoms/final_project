using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ui_script : MonoBehaviour
{
    public global_script global_script;
    public player_script player_script;

    public Text score;
    public Text ammo;
    public Text health;

    void FixedUpdate()
    {
        score.text = "Score: " + global_script.playerScore;
        ammo.text = "Ammo: " + player_script.ammo;
        health.text = "Health: " + player_script.displayHealth;
    }
}