using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    [SerializeField] private ParticleSystem snowFX;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            snowFX.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        snowFX.Pause();
    }

}
