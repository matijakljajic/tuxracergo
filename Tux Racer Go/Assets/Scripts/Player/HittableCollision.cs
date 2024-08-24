using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hittable"))
        {
            Debug.Log("Player: Hit something!");
            FindObjectOfType<AudioManager>().Play("Hit");
        }
    }

}
