using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds rotation constraint to an object. Fixes ramp shenanigans.
/// </summary>
public class RotationConstrainer : MonoBehaviour
{
    [SerializeField] public float minXRotation = -45f;
    [SerializeField] public float maxXRotation = 45f;

    void FixedUpdate()
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
