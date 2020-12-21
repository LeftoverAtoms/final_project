using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_s : MonoBehaviour
{
    public global_s global_s;

    void FixedUpdate()
    {
        MouseController();
    }

    void MouseController()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * global_s.mouseSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * global_s.mouseSpeed;

        Vector3 MousePos = global_s.mouseCursor.transform.position + new Vector3(mouseX, 0, mouseY);
        Vector3 offset = MousePos - global_s.player.transform.position;
        global_s.mouseCursor.transform.position = global_s.player.transform.position + Vector3.ClampMagnitude(offset, 2);
    }
}