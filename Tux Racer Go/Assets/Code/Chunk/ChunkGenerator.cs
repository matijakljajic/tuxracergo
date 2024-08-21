using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{

    [SerializeField] public List<GameObject> starterChunks;
    [SerializeField] public List<GameObject> entranceChunks;
    [SerializeField] public List<GameObject> blankyBiomeChunks;
    [SerializeField] public List<GameObject> forestBiomeChunks;
    [SerializeField] public List<GameObject> icicleBiomeChunks;
    private int biomeType;

    private void Start()
    {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        biomeType = 0;

        Instantiate(starterChunks[0], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2.5f, gameObject.transform.position.z + 260), Quaternion.identity);
        Instantiate(starterChunks[1], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2.5f, gameObject.transform.position.z + 1060), Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Chunk Generation"))
        {
            GameObject toGenerate = null;

            switch (biomeType)
            {
                case 0:
                    toGenerate = entranceChunks[UnityEngine.Random.Range(0, entranceChunks.Count)];
                    Debug.Log("List count: " + entranceChunks.Count);
                    break;
                case 1:
                    toGenerate = blankyBiomeChunks[UnityEngine.Random.Range(0, blankyBiomeChunks.Count)];
                    break;
                case 2:
                    toGenerate = forestBiomeChunks[UnityEngine.Random.Range(0, forestBiomeChunks.Count)];
                    break;
                case 3:
                    toGenerate = icicleBiomeChunks[UnityEngine.Random.Range(0, icicleBiomeChunks.Count)];
                    break;
            }

            Instantiate(toGenerate, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 1201), Quaternion.identity);
        }

    }

}
