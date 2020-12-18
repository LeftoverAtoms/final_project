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

    private int playerMaxHealth = 100;
    private float playerHealth = 100;
    private float playerHealthTime;
    public float displayHealth;

    private float playerMoveSpeed = 0.125f;

    private float currentTime;
    private bool playerHasShot;
    public float rateOfFire;
    public int ammo;

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

        if (Input.GetKey(KeyCode.Mouse0) && playerHasShot == false && ammo > 0)
        {
            projectile_script.ProjectilePrefab();                                                                      //Spawns the projectile prefab.
            playerHasShot = true;
            ammo--;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))               //Checks if the raycast hit an enemy and if so it deletes it.
            {
                Destroy(hit.transform.gameObject);

                global_script.playerScore = global_script.playerScore + 50;
                entity_spawn_script.currentEnemyCount--;
                return;
            }
        }

        if (playerHasShot)                                                                                             //If "playerHasShot" = true then counts up to compare the time with "rateOfFire" and resets.
        {
            currentTime = currentTime + 1 * Time.deltaTime;
            if (currentTime > rateOfFire)
            {
                playerHasShot = false;
                currentTime = 0;
                return;
            }
        }
    }

    void PlayerController()
    {
        float keyboardX = Input.GetAxis("Horizontal");                                                                 //Input for keyboard.
        float keyboardY = Input.GetAxis("Vertical");                                                                   //Input for keyboard.
        player.transform.LookAt(mouseCursor.transform.position);                                                       //Mouse movement dictates where the player will look.
        player.transform.Translate(keyboardX * playerMoveSpeed, 0, keyboardY * playerMoveSpeed, Space.World);          //Player movement.
        mouseCursor.transform.Translate(keyboardX * playerMoveSpeed, 0, keyboardY * playerMoveSpeed, Space.World);     //Janky way to make the mouseCursor GameObject to move with the player.
    }

    void HealthSystem()
    {
        displayHealth = (Mathf.RoundToInt(playerHealth));
        displayHealth = Mathf.Clamp(displayHealth, 0, 100);
        if (playerHealth < playerMaxHealth)
        {
            playerHealthTime = playerHealthTime + 1 * Time.deltaTime;
            if (playerHealthTime == 1)
            {
                playerHealth = playerHealth + 25 * Time.deltaTime;
                if (playerHealth == playerMaxHealth)
                {
                    playerHealthTime = 0;
                    return;
                }
            }
        }

        if (playerHealth <= 0)
        {
            player.SetActive(false);
            mouseCursor.SetActive(false);
            return;
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "enemy")
        {
            playerHealth = playerHealth - 50;
            playerHealthTime = 0;
            return;
        }
    }
}