using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Collectable"))
        {
            gameManager.herringCollected++;
            audioManager.Play("PickUp" + Random.Range(1, 3));
            Destroy(other.gameObject);
        }
    }
}
