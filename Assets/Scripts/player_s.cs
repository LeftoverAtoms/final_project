using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class player_s : MonoBehaviour
{
    public global_s global_s;

    public projectile_s projectile_s;

    private float playerHealthTimeFloat;
    private int playerMaxHealth = 100;
    private int playerHealthTime;

    private float rateOfFire = 0.1f;
    private float playerShotTime;

    private float playerMoveSpeed = 0.125f;

    private int randomGenerator;

    void FixedUpdate()
    {
        PlayerController();
        PlayerHealth();
        Projectile();
    }

    void Projectile()
    {
        LayerMask mask = LayerMask.GetMask("enemy");
        RaycastHit hit;

        playerShotTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && playerShotTime >= rateOfFire && global_s.playerAmmo > 0)
        {
            projectile_s.ProjectilePrefab();

            global_s.playerAmmo -= 1;
            playerShotTime = 0;

            if (Physics.Raycast(global_s.player.transform.position, global_s.player.transform.forward, out hit, 50, mask))
            {
                Destroy(hit.transform.gameObject);

                AmmoDrop();

                global_s.determinedEnemyCount -= 1;
                global_s.playerScore += 50;
            }
        }
    }

    void PlayerController()
    {
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardY = Input.GetAxis("Vertical");

        global_s.mouseCursor.transform.Translate(keyboardX * playerMoveSpeed, 0, keyboardY * playerMoveSpeed, Space.World);
        global_s.player.transform.Translate(keyboardX * playerMoveSpeed, 0, keyboardY * playerMoveSpeed, Space.World);

        Vector3 lookAt = new Vector3(global_s.mouseCursor.transform.position.x, global_s.player.transform.position.y, global_s.mouseCursor.transform.position.z);
        global_s.player.transform.LookAt(lookAt);
    }

    void PlayerHealth()
    {
        if (global_s.playerHealth < playerMaxHealth)
        {
            playerHealthTime = Mathf.RoundToInt(playerHealthTimeFloat);
            playerHealthTimeFloat += 0.25f * Time.deltaTime;
            if (playerHealthTime >= 1)
            {
                global_s.playerHealth += 1;
                if (global_s.playerHealth >= playerMaxHealth)
                {
                    playerHealthTime = 0;
                }
            }
        }

        if (global_s.playerHealth <= 0)
        {
            global_s.mouseCursor.SetActive(false);
            global_s.restartHint.SetActive(true);
            global_s.player.SetActive(false);
        }
    }

    void AmmoDrop()
    {
        randomGenerator = Random.Range(0, 4);

        if (randomGenerator == 0)
        {
            global_s.playerAmmo += 2;
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "enemy")
        {
            playerHealthTimeFloat = 0;
            global_s.playerHealth -= 50;
        }
    }
}