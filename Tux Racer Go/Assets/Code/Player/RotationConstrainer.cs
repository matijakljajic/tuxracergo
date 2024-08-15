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
        // Get current rotation
        Vector3 currentRotation = transform.localEulerAngles;

        // Convert the X rotation to a value between -180 and 180
        if (currentRotation.x > 180f)
        {
            currentRotation.x -= 360f;
        }

        // Clamp the rotation within the allowed range
        currentRotation.x = Mathf.Clamp(currentRotation.x, minXRotation, maxXRotation);

        // Apply the clamped rotation
        transform.localEulerAngles = currentRotation;
    }
}
