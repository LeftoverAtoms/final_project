using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class global_s : MonoBehaviour
{
    public GameObject instantiate_enemy;

    public GameObject restartHint;
    public GameObject mouseCursor;
    public GameObject player;
    public GameObject enemy;
    public GameObject cam;

    public Text playerAmmoText;
    public Slider healthBar;
    public Text enemies;
    public Text score;
    public Text wave;

    public float determinedEnemyCount;
    public int waveCount;

    public float mouseSpeed;

    public int playerHealth = 100;
    public int playerAmmo = 25;
    public int playerScore;
    public float shopWait;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        waveCount += 1;
    }

    void FixedUpdate()
    {
        Restart();
        Shop();
        UI();
    }

    void Restart()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Shop()
    {
        shopWait += 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.B) && playerScore >= 250 && shopWait >= 0.5f)
        {
            shopWait = 0;
            playerScore -= 250;
            playerAmmo += 10;
        }
    }

    void UI()
    {
        playerAmmoText.text = "Ammo: " + playerAmmo;
        healthBar.value = playerHealth;
        score.text = "Score: " + playerScore;
        wave.text = "Round: " + waveCount;
        enemies.text = "Enemies: " + determinedEnemyCount;
    }
}