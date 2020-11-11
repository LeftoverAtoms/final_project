using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.5f;

    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.Translate(0, 0, speed);
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKeyDown("s"))
        {
            transform.Translate(0, 0, -speed);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(speed, 0, 0);
        }
    }
}
