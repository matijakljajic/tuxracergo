using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Canvas pauseCanvas;

    private static bool paused = false;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        paused = false;
        Cursor.visible = false;

        Time.timeScale = 1f;

        audioManager.Resume("RaceTheme");

        pauseCanvas.gameObject.SetActive(false);
    }

    public void Pause()
    {
        paused = true;
        Cursor.visible = true;

        Time.timeScale = 0f;

        audioManager.Pause("RaceTheme");
        audioManager.Stop("SnowSlide");
        audioManager.Stop("IceSlide");

        pauseCanvas.gameObject.SetActive(true);
    }

    public void GiveUp()
    {
        paused = false;
        Cursor.visible = true;
        
        Time.timeScale = 1f;

        audioManager.Play("RaceTheme");
        audioManager.Stop("RaceTheme");
        audioManager.Play("MenuTheme");
        SceneManager.LoadScene(0);
    }

}
