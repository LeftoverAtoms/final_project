using UnityEngine;

namespace DOA
{
    public class Player : MonoBehaviour
    {
        public Global global;

        public Projectile projectile;

        float playerHealthTimeFloat;
        int playerMaxHealth = 100;
        int playerHealthTime;

        float rateOfFire = 0.3f;
        float playerShotTime;

        float playerMoveSpeed = 0.125f;

        int randomGenerator;

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

            if (Input.GetKey(KeyCode.Mouse0) && playerShotTime >= rateOfFire && global.playerAmmo > 0)
            {
                projectile.ProjectilePrefab();

                global.playerAmmo -= 1;
                playerShotTime = 0;

                if (Physics.Raycast(global.player.transform.position, global.player.transform.forward, out hit, 50, mask))
                {
                    Destroy(hit.transform.gameObject);

                    AmmoDrop();

                    global.determinedEnemyCount -= 1;
                    global.playerScore += 50;
                }
            }
        }

        void PlayerController()
        {
            float keyboardX = Input.GetAxis("Horizontal");
            float keyboardY = Input.GetAxis("Vertical");

            global.mouseCursor.transform.Translate(keyboardX * playerMoveSpeed, 0, keyboardY * playerMoveSpeed, Space.World);
            global.player.transform.Translate(keyboardX * playerMoveSpeed, 0, keyboardY * playerMoveSpeed, Space.World);

            Vector3 lookAt = new Vector3(global.mouseCursor.transform.position.x, global.player.transform.position.y, global.mouseCursor.transform.position.z);
            global.player.transform.LookAt(lookAt);
        }

        void PlayerHealth()
        {
            if (global.playerHealth < playerMaxHealth)
            {
                playerHealthTime = Mathf.RoundToInt(playerHealthTimeFloat);
                playerHealthTimeFloat += 0.25f * Time.deltaTime;
                if (playerHealthTime >= 1)
                {
                    global.playerHealth += 1;
                    if (global.playerHealth >= playerMaxHealth)
                    {
                        playerHealthTime = 0;
                    }
                }
            }

            if (global.playerHealth <= 0)
            {
                global.mouseCursor.SetActive(false);
                global.restartHint.SetActive(true);
                global.player.SetActive(false);
            }
        }

        void AmmoDrop()
        {
            randomGenerator = Random.Range(0, 4);

            if (randomGenerator == 0)
            {
                global.playerAmmo += 2;
            }
        }

        void OnCollisionEnter(Collision Collision)
        {
            if (Collision.gameObject.tag == "enemy")
            {
                playerHealthTimeFloat = 0;
                global.playerHealth -= 50;
            }
        }
    }
}