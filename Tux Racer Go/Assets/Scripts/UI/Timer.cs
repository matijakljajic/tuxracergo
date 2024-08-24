using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float elapsedTime;

    [SerializeField] public GameManager gameManager;

    private void Awake()
    {
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (TimerIsRunning())
        {
            elapsedTime += Time.deltaTime;
            displayTimer();
        }
    }

    private bool TimerIsRunning()
    {
        return gameManager.timerIsRunning;
    }

    private void displayTimer()
    {
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime % 1) * 1000;

        gameObject.GetComponent<Text>().text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
