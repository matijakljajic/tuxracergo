using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [Space]
    [SerializeField] private float positionSmoothing;
    [SerializeField] private float rotationSmoothing;

    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, player.position, positionSmoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotationSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));

    }
}
