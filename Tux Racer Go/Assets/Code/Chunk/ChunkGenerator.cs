using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{

    [SerializeField] public GameObject chunk;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Chunk Generation"))
        {
            Instantiate(chunk, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 2801), Quaternion.identity);
        }

    }

}
