using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Basic chunk generation following biome rules.
/// </summary>
public class ChunkGenerator : MonoBehaviour
{

    [SerializeField] private List<GameObject> starterChunks;
    [SerializeField] private List<GameObject> entranceChunks;
    [SerializeField] private List<GameObject> blankyBiomeChunks;
    [SerializeField] private List<GameObject> forestBiomeChunks;
    [SerializeField] private List<GameObject> icicleBiomeChunks;
    
    private int biomeType;
    private int biomeChunkCount;

    private void Start()
    {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        biomeType = 0;
        biomeChunkCount = 0;

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
                    EntranceChunkGeneratorHelper(toGenerate);
                    break;
                case 1:
                    toGenerate = blankyBiomeChunks[UnityEngine.Random.Range(0, blankyBiomeChunks.Count)];
                    BiomeChunkGeneratorHelper(toGenerate, blankyBiomeChunks);
                    break;
                case 2:
                    toGenerate = forestBiomeChunks[UnityEngine.Random.Range(0, forestBiomeChunks.Count)];
                    BiomeChunkGeneratorHelper(toGenerate, forestBiomeChunks);
                    break;
                case 3:
                    toGenerate = icicleBiomeChunks[UnityEngine.Random.Range(0, icicleBiomeChunks.Count)];
                    BiomeChunkGeneratorHelper(toGenerate, icicleBiomeChunks);
                    break;
            }

            // I thought of doing inversion of chunks as that introduces more possibilities but Terrain objects are static ergo not rotatable
            // bool inverted = UnityEngine.Random.value < 0.5f; -> inverted != true ? Quaternion.identity : Quaternion.identity * Quaternion.Euler(0f, 180f, 0f)
            // One possible solution is to convert all Terrain objects into meshes, but I need Terrain systems for different ground types

            Instantiate(toGenerate, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 1201), Quaternion.identity);
        }

    }

    private void EntranceChunkGeneratorHelper(GameObject toGenerate)
    {
        biomeChunkCount = 0;
        switch (toGenerate.name)
        {
            case "Blank":
                biomeType = 1;
                break;
            case "Forest":
                biomeType = 2;
                break;
            case "Icicle":
                biomeType = 3;
                break;
        }
    }

    private void BiomeChunkGeneratorHelper(GameObject toGenerate, List<GameObject> biomeChunks)
    {
        biomeChunkCount++;
        if (biomeChunkCount == biomeChunks.Count + 3)
        {
            biomeType = 0;
        }
    }

}
