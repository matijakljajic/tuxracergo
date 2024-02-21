using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // object we want to follow
    public Vector3 positionOffset; // camera offset from target
    public float smoothness = 0.3f; // camera speed

    void LateUpdate()
    {
        // vector addition
        Vector3 desiredPosition = target.position + positionOffset;
        transform.position = Vector3.Slerp(desiredPosition, target.position, smoothness);
    
        transform.LookAt(target);

    }

}
