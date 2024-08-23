using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkDestructor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Chunk Destruction"))
        {
            Destroy(gameObject);
            Debug.Log("Object Destroyed!");
        }

    }

}
