using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Cursor.visible = false;

        AudioManager am = FindObjectOfType<AudioManager>();
        am.Stop("MenuTheme");
        am.Play("RaceTheme");

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
