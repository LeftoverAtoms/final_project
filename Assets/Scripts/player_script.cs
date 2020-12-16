using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public entity_spawn_script _entity_spawn_script;
    public projectile_script _projectile_script;
    public global_variables _global_variables;
    public mouse_script _mouse_script;

    public GameObject mouseCursor;
    public GameObject player;
    public GameObject enemy;

    private float moveSpeed = 0.125f;

    private float rateOfFire = 0.125f;
    private float currentTime;
    private bool hasShot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        _mouse_script.MouseController();
        Projectile();
        PlayerController();
    }

    void Projectile()
    {
        LayerMask mask = LayerMask.GetMask("enemy");
        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse0) && hasShot == false)
        {
            _projectile_script.ProjectilePrefab();                                                                     //Spawns the projectile prefab.
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))               //Checks if the raycast hit an enemy and if so it deletes it.
            {
                Destroy(hit.transform.gameObject);
                VariableChanges();
                Debug.Log("DAMGE_ENEMY");
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

    void VariableChanges()
    {
        _global_variables.playerScore = _global_variables.playerScore + 50;
        _entity_spawn_script.currentEnemyCount--;
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "enemy")                                                                       //Checks if enemy touched the player.
        {
            Debug.Log("DAMAGE_PLAYER");
        }
    }
}