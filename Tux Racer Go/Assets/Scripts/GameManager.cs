using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int herringCollected;

    public bool timerIsRunning;

    private void Awake()
    {
        herringCollected = 0;
        timerIsRunning = true;
    }

}
