using UnityEngine;

namespace DOA
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] Global global;

        void FixedUpdate()
        {
            global.cam.transform.position = new Vector3(global.player.transform.position.x, 25, global.player.transform.position.z);
        }
    }
}