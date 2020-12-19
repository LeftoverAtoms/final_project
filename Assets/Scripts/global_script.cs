using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_script : MonoBehaviour
{
    public GameObject mouseCursor;
    public GameObject player;
    public GameObject enemy;

    public float playerScore;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}