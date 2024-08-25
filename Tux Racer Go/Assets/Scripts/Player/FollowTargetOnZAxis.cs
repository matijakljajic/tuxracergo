using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetOnZAxis : MonoBehaviour
{
    [SerializeField] private Transform target;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z - 1600);
    }
}
