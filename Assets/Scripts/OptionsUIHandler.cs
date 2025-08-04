using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static UnityEditor.Progress;

public class OptionsUIHandler : MonoBehaviour
{
    [Inject] AudioManager audioManager;
    [Inject] DisplaySettingsManager displayManager;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSFX;
    [SerializeField] Slider sliderMaster;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown qualityDropdown;
    [SerializeField] Toggle fullScreenToggle;
    
    private void Start()
    {
        LoadResolution();
        LoadSliders();
        FullScreenToggle();
        LoadQualityChange();
    }

    public void LoadQualityChange()
    {
        qualityDropdown.AddOptions(QualitySettings.names.ToList());
        qualityDropdown.onValueChanged.AddListener(delegate
        {
            QualitySettings.SetQualityLevel(qualityDropdown.value);
        });
    }

    public void FullScreenToggle()
    {
        fullScreenToggle.onValueChanged.AddListener(delegate
        {
            displayManager.SetFullScreen(fullScreenToggle.isOn);
        });

        fullScreenToggle.isOn = displayManager.GetFullScreen();

    }
    public void LoadResolution()
    {
        List<string> resolutions = new();

        foreach (var item in Screen.resolutions)
        {
            resolutions.Add(resolutionGame(item));
        }
        resolutionDropdown.AddOptions(resolutions);

        resolutionDropdown.onValueChanged.AddListener(delegate
        {
            displayManager.SetResolution(resolutionDropdown.value);
        });
    }
    public string resolutionGame(Resolution resolution)
    {
        return resolution.width + " x " + resolution.height + " rate " + resolution.refreshRateRatio.value.ToString("F0");
    }

    public void LoadSliders()
    {
        sliderMusic.onValueChanged.AddListener(delegate
        {
            audioManager.ChangeMusicVolume(sliderMusic.value);
        });

        sliderSFX.onValueChanged.AddListener(delegate
        {
            audioManager.ChangeSFXVolume(sliderSFX.value);
        });

        sliderMaster.onValueChanged.AddListener(delegate
        {
            audioManager.ChangeMasterVolume(sliderMaster.value);
        });

        sliderMusic.value = audioManager.GetMusicVolume();
        sliderSFX.value = audioManager.GetSFXVolume();
        sliderMaster.value = audioManager.GetMasterVolume();
    }
}
