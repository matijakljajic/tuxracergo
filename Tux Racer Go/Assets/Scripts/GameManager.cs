using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int herringCollected;
    public float elapsedTime;

    private void Awake()
    {
        herringCollected = 0;
        elapsedTime = 0f;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

}
