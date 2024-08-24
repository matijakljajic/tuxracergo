using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlideSoundPlayer : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            audioManager.Play("SnowSlide");
        if (collision.gameObject.CompareTag("Ice"))
            audioManager.Play("IceSlide");
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            audioManager.Stop("SnowSlide");
        if (collision.gameObject.CompareTag("Ice"))
            audioManager.Stop("IceSlide");
    }

}
