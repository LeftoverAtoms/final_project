using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_script : MonoBehaviour
{
    public global_script global_script;

    public float mouseSpeed;

    public void MouseController()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed;

        Vector3 MousePos = global_script.mouseCursor.transform.position + new Vector3(mouseX, 0, mouseY);
        Vector3 offset = MousePos - global_script.player.transform.position;
        global_script.mouseCursor.transform.position = global_script.player.transform.position + Vector3.ClampMagnitude(offset, 2);
    }
}