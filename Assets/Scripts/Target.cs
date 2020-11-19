using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;
    public float speed;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;              //Locks cursor
        Cursor.visible = false;                                //Hides cursor
    }

    public void Update()
    {
        float x = Input.GetAxis("Mouse X");                    //Gets mouse X input
        float y = Input.GetAxis("Mouse Y");                    //Gets mouse Y input
        target.transform.Translate(x * speed, 0, y * speed);   //Applies inputs to the target prefab
    }
}