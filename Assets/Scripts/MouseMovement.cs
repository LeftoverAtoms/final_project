using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject aim;
    public float mSpeed;
    public float kbSpeed;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                             //Locks cursor
        Cursor.visible = false;                                               //Hides cursor
    }

    public void FixedUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);   //Keeps mouse in view
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        float kbx = Input.GetAxis("Horizontal");                              //Gets keyboard X input
        float kby = Input.GetAxis("Vertical");                                //Gets keyboard Z input

        float x = Input.GetAxis("Mouse X");                                   //Gets mouse X input
        float y = Input.GetAxis("Mouse Y");                                   //Gets mouse Z input
        aim.transform.Translate(x * mSpeed, 0, y * mSpeed);                   //Applies mouse inputs
        aim.transform.Translate(kbx * kbSpeed, 0, kby * kbSpeed);             //Applies keyboard inputs
    }
}