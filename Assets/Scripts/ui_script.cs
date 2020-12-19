using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ui_script : MonoBehaviour
{
    public global_script global_script;
    public player_script player_script;

    public Slider healthBar;
    public Text playerAmmo;
    public Text score;

    void FixedUpdate()
    {
        playerAmmo.text = "Ammo: " + player_script.playerAmmo;
        score.text = "Score: " + global_script.playerScore;
        healthBar.value = player_script.playerHealth;
    }
}