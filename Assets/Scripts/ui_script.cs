using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_script : MonoBehaviour
{
    public global_script global_script;
    public player_script player_script;

    public Text score;
    public Text playerAmmo;
    public Slider healthBar;

    void FixedUpdate()
    {
        score.text = "Score: " + global_script.playerScore;
        playerAmmo.text = "Ammo: " + player_script.playerAmmo;
        healthBar.value = player_script.playerHealth;
    }
}