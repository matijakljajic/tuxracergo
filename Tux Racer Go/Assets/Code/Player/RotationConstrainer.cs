using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds X axis rotation constraint to an object. Cheaply fixes some physics shenanigans.
/// </summary>
public class RotationConstrainer : MonoBehaviour
{
    [SerializeField] public float minXRotation;
    [SerializeField] public float maxXRotation;

    void LateUpdate()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        if (currentRotation.x > 180f)
        {
            currentRotation.x -= 360f;
        }

        currentRotation.x = Mathf.Clamp(currentRotation.x, minXRotation, maxXRotation);

        transform.localEulerAngles = currentRotation;
    }
}
