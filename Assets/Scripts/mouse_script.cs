using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_script : MonoBehaviour
{
    public GameObject mouseCursor;

    public void MouseController()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        mouseCursor.transform.Translate(mouseX, 0, mouseY);
    }
}

//public GameObject player;

//Vector3 MousePos = mouseCursor.transform.position + new Vector3(mouseX, 0, mouseY);
//Vector3 offset = MousePos - player.transform.position;
//mouseCursor.transform.position = player.transform.position + Vector3.ClampMagnitude(offset, radius);