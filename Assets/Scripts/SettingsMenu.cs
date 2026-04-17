using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public Slider musicSlider;
    public Slider soundEffectSlider;
    public void Start()
    {
        audioMixer.GetFloat("Music", out float musicValue);
        audioMixer.GetFloat("SoundEffect", out float soundEffectValue);

        musicSlider.value = musicValue;
        soundEffectSlider.value = soundEffectValue;

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;
    }
    public void SetVolume(float volume)
    {
        // Implémentez la logique pour ajuster le volume du jeu
        //Debug.Log("Volume réglé à : " + volume);
        audioMixer.SetFloat("Music", volume);
    }

        public void SetSoundVolume(float volume)
    {
        // Implémentez la logique pour ajuster le volume du jeu
        //Debug.Log("Volume réglé à : " + volume);
        audioMixer.SetFloat("SoundEffect", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        // Implémentez la logique pour basculer entre le mode plein écran et le mode fenêtré
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Toutes les données sauvegardées ont été supprimées.");
    }
}
