using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject aim;
    public float speed;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                             //Locks cursor
        Cursor.visible = false;                                               //Hides cursor
    }

    public void Update()
    {
        float x = Input.GetAxis("Mouse X");                                   //Gets mouse X input
        float y = Input.GetAxis("Mouse Y");                                   //Gets mouse Y input
        aim.transform.Translate(x * speed, 0, y * speed);                     //Applies inputs to the target prefab
    }

    public void FixedUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);   //Keeps mouse in view
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}