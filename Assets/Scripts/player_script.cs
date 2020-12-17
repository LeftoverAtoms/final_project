using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public entity_spawn_script entity_spawn_script;
    public projectile_script projectile_script;
    public global_script global_script;
    public mouse_script mouse_script;

    public GameObject mouseCursor;
    public GameObject player;
    public GameObject enemy;

    private float healthCurrentTime;
    private int maxHealth = 100;
    private float health = 100;
    public float displayHealth;

    private float moveSpeed = 0.125f;

    private float rateOfFire = 0.125f;
    private float currentTime;
    private bool hasShot;

    void FixedUpdate()
    {
        mouse_script.MouseController();
        Projectile();
        HealthSystem();
        PlayerController();
    }

    void Projectile()
    {
        LayerMask mask = LayerMask.GetMask("enemy");
        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse0) && hasShot == false)
        {
            projectile_script.ProjectilePrefab();                                                                      //Spawns the projectile prefab.
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))               //Checks if the raycast hit an enemy and if so it deletes it.
            {
                Destroy(hit.transform.gameObject);

                global_script.playerScore = global_script.playerScore + 50;
                entity_spawn_script.currentEnemyCount--;
            }
            hasShot = true;
        }

        if (hasShot)                                                                                                   //If "hasShot" = true then counts up to compare the time with "rateOfFire" and resets.
        {
            currentTime = currentTime + 1 * Time.deltaTime;
            if (currentTime > rateOfFire)
            {
                hasShot = false;
                currentTime = 0;
            }
        }
    }

    void PlayerController()
    {
        float keyboardX = Input.GetAxis("Horizontal");                                                                 //Input for keyboard.
        float keyboardY = Input.GetAxis("Vertical");                                                                   //Input for keyboard.
        player.transform.LookAt(mouseCursor.transform.position);                                                       //Mouse movement dictates where the player will look.
        player.transform.Translate(keyboardX * moveSpeed, 0, keyboardY * moveSpeed, Space.World);                      //Player movement.
        mouseCursor.transform.Translate(keyboardX * moveSpeed, 0, keyboardY * moveSpeed, Space.World);                 //Janky way to make the mouseCursor GameObject to move with the player.
    }

    void HealthSystem()
    {
        displayHealth = (Mathf.RoundToInt(health));
        if (health < maxHealth)
        {
            healthCurrentTime = healthCurrentTime + 1 * Time.deltaTime;
            if (healthCurrentTime > 1)
            {
                health = health + 25 * Time.deltaTime;
                if (health == maxHealth)
                {
                    healthCurrentTime = 0;
                }
                else if (health > maxHealth)
                {
                    return;
                }
            }
        }

        if (health <= 0)
        {
            player.SetActive(false);
            mouseCursor.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "enemy")
        {
            health = health - 50;
        }
    }
}