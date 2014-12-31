using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        if (!Target)
            return;

        var playerPosition = Target.position;

        if (playerPosition.y >= transform.position.y)
            transform.position = new Vector3(transform.position.x, playerPosition.y, transform.position.z);
    }
}
