using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    private const string PERCENTAGE_SYMBOL = "%";

    public Sprite volumeOffIcon;
    public Sprite volumeOnIcon;
    [SerializeField] private float minVolume = -80f;
    public Dropdown resolutionDropDown;

    [Header("Audio Master")]
    public AudioMixer audioMixerMaster;
    public TextMeshProUGUI textAudioMaster;
    public Image volumeIconAudioMaster;

    [Header("Audio Music")]
    public AudioMixerGroup audioMixerMusic;
    public TextMeshProUGUI textAudioMusic;
    public Image volumeIconAudioMusic;

    [Header("Audio SFX")]
    public AudioMixerGroup audioMixerSFX;
    public TextMeshProUGUI textAudioSFX;
    public Image volumeIconAudioSFX;

    public void setMasterVolumen(float volume)
    {
        audioMixerMaster.SetFloat("volume", volume);
        textAudioMaster.text = Mathf.RoundToInt((volume + Math.Abs(minVolume)) * (100 / Math.Abs(minVolume))) + PERCENTAGE_SYMBOL;
        volumeIconAudioMaster.sprite = volume == -80f ? volumeOffIcon : volumeOnIcon;
    }
    public void setMusicVolumen(float volume)
    {
        audioMixerMusic.audioMixer.SetFloat("MusicVolume", volume);
        textAudioMusic.text = Mathf.RoundToInt((volume + Math.Abs(minVolume)) * (100 / Math.Abs(minVolume))) + PERCENTAGE_SYMBOL;
        volumeIconAudioMusic.sprite = volume == -80f ? volumeOffIcon : volumeOnIcon;
    }
    public void setSFXVolumen(float volume)
    {
        audioMixerSFX.audioMixer.SetFloat("SFXVolume", volume);
        textAudioSFX.text = Mathf.RoundToInt((volume + Math.Abs(minVolume)) * (100 / Math.Abs(minVolume))) + PERCENTAGE_SYMBOL;
        volumeIconAudioSFX.sprite = volume == -80f ? volumeOffIcon : volumeOnIcon;
    }
    public void setFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void goMainMenu()
    {
        AudioManager.instance.Play("ClickCancelar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && //Screen.CurrentResolution.width
                resolutions[i].height == Screen.height) //Screen.CurrentResolution.height
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        float currentVolume;
        audioMixerMaster.GetFloat("volume", out currentVolume);
        volumeIconAudioMaster.sprite = currentVolume == -80 ? volumeOffIcon : volumeOnIcon;
        audioMixerMusic.audioMixer.GetFloat("MusicVolume", out currentVolume);
        volumeIconAudioMusic.sprite = currentVolume == -80 ? volumeOffIcon : volumeOnIcon;
        audioMixerSFX.audioMixer.GetFloat("SFXVolume", out currentVolume);
        volumeIconAudioSFX.sprite = currentVolume == -80 ? volumeOffIcon : volumeOnIcon;
    }
}
