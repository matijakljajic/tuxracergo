using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] public string themeToStop;
    [SerializeField] public string themeToPlay;

    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        audioManager.Stop(themeToStop);
        audioManager.Play(themeToPlay);
    }

}
