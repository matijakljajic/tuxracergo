using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private int herrigns_Collected;
    
    private void Start()
    {
        herrigns_Collected = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Collectable"))
        {
            herrigns_Collected++;
            Destroy(other.gameObject);
        }
    }
}
