using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_script : MonoBehaviour
{
    public float playerScore;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}