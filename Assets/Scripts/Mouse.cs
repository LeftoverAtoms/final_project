using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;                              //Hides cursor
        float horizontal = Input.GetAxis("Mouse X");                           //Gets mouse X input
        float vertical = Input.GetAxis("Mouse Y");                             //Gets mouse Y input
        target.transform.Translate(horizontal * speed, 0, vertical * speed);   //Applies the mouse XY inputs to the target
    }
}