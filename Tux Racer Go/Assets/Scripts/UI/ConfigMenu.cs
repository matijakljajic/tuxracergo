using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{

    [SerializeField] private Dropdown resDropdown;
    [SerializeField] private AudioMixer mixer;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        List<string> list = new List<string>();
        int currRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            list.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currRes = i;
            }
        }

        resDropdown.ClearOptions();
        resDropdown.AddOptions(list);
        resDropdown.value = currRes;
        resDropdown.RefreshShownValue();
    }

    public void SetMusicVolume(float val)
    {
        mixer.SetFloat("MusicVol", val);
    }

    public void SetSFXVolume(float val)
    {
        mixer.SetFloat("SFXVol", val);
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
