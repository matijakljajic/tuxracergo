using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableCollision : MonoBehaviour
{
    [SerializeField] public Canvas canvasToHide;
    [SerializeField] public Canvas canvasToShow;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hittable"))
        {
            audioManager.Play("Hit");
            audioManager.Stop("RaceTheme");
            audioManager.Stop("SnowSlide");
            audioManager.Stop("IceSlide");

            Time.timeScale = 0f;

            canvasToHide.gameObject.SetActive(false);
            canvasToShow.gameObject.SetActive(true);
        }
    }

}
