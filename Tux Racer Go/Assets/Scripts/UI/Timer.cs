using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private string prefix;

    private void Update()
    {
        DisplayTimer();
    }

    private void DisplayTimer()
    {
        float minutes = Mathf.FloorToInt(gameManager.elapsedTime / 60);
        float seconds = Mathf.FloorToInt(gameManager.elapsedTime % 60);
        float milliseconds = (gameManager.elapsedTime % 1) * 1000;

        gameObject.GetComponent<Text>().text = string.Concat(prefix, string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds));
    }
}
