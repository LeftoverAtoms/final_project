using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject aim;
    public float mSpeed;
    public float kbSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        float kbx = Input.GetAxis("Horizontal");
        float kby = Input.GetAxis("Vertical");

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        aim.transform.Translate(x * mSpeed, 0, y * mSpeed);
        aim.transform.Translate(kbx * kbSpeed, 0, kby * kbSpeed);
    }
}