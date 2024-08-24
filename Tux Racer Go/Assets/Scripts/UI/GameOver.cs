using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] public AudioManager audioManager;

    private void OnEnable()
    {
        audioManager = FindObjectOfType<AudioManager>();

        int val = Mathf.FloorToInt(gameManager.elapsedTime / 60) + 1;

        Cursor.visible = true;

        if (gameManager.herringCollected / val <= 24)
        {
            audioManager.Play("RaceLoserTheme");
        }
        else
        {
            audioManager.Play("RaceWinnerTheme");
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        audioManager.Stop("RaceWinnerTheme");
        audioManager.Stop("RaceLoserTheme");
        audioManager.Play("MenuTheme");
    }

}
