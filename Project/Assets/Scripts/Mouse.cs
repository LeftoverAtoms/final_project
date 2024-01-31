using UnityEngine;

namespace DOA
{
    public class Mouse : MonoBehaviour
    {
        [SerializeField] Global global;

        void FixedUpdate()
        {
            MouseController();
        }

        void MouseController()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * global.mouseSpeed;
            float mouseY = Input.GetAxisRaw("Mouse Y") * global.mouseSpeed;

            Vector3 MousePos = global.mouseCursor.transform.position + new Vector3(mouseX, 0, mouseY);
            Vector3 offset = MousePos - global.player.transform.position;
            global.mouseCursor.transform.position = global.player.transform.position + Vector3.ClampMagnitude(offset, 2);
        }
    }
}