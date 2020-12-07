using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public GameObject player;
    public GameObject aim;
    public GameObject enemy;
    public projectile_prefab_script projectile_script;

    public float speed;

    private float currentTime;
    private bool has_shot;
    public float rof;

    public AudioClip TEMP_fire;
    public AudioClip TEMP_beep;
    AudioSource audioSource;

    void Start() //CALLED AT START
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate() //UPDATES EVERY FRAME
    {
        ProjectileLogic(); //RAYCAST AND PREFAB SPAWNING
        PlayerController(); //PLAYER CONTROLLER
    }

    void ProjectileLogic() //RAYCAST AND PREFAB SPAWNING
    {
        LayerMask mask = LayerMask.GetMask("enemy");
        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse0) && has_shot == false)
        {
            projectile_script.Projectile_Prefab_Spawn();

            audioSource.PlayOneShot(TEMP_fire, 0.7F);

            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 50, mask))
            {
                Destroy(hit.transform.gameObject);
                audioSource.PlayOneShot(TEMP_beep, 0.7F);
                Debug.Log("DAMGE_ENEMY");
            }
            has_shot = true;
        }

        if (has_shot)
        {
            currentTime = currentTime + 1 * Time.deltaTime;
            if (currentTime > rof)
            {
                has_shot = false;
                currentTime = 0;
            }
        }
    }

    void PlayerController() //PLAYER CONTROLLER
    {
        player.transform.LookAt(aim.transform);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        player.transform.Translate(x * speed, 0, y * speed, Space.World);
    }

    void OnCollisionEnter(Collision Collision) //COLLISION DETECTION
    {
        if (Collision.gameObject.tag == "enemy")
        {
            Debug.Log("DAMAGE_PLAYER");
        }
    }
}