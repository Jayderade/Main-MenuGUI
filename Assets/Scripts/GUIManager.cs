using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public bool showControls;
    public bool showOptions;
    public GameObject menu, options, controls;
    public AudioSource mainMusic;
    public Slider volumeSlider, brightnessSlider;
    public Light brightness;

    void Start()
    {
        
        if(mainMusic != null && volumeSlider != null)
        {
            if (PlayerPrefs.HasKey("Volume"))
            {
                Load();
            }
            volumeSlider.value = mainMusic.volume;
        }
        if(brightness != null && brightnessSlider != null)
        {
            brightnessSlider.value = brightness.intensity;
        }
    }
    void Update()
    {
       if(volumeSlider.value != mainMusic.volume)
        {
            mainMusic.volume = volumeSlider.value;
        }
        if (brightnessSlider.value != brightness.intensity)
        {
            brightness.intensity = brightnessSlider.value;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowOptions()
    {
        ToggleOptions();
    }
    public void ShowControls()
    {
        ToggleControls();
    }
      public void Back()
    {
        if (showControls)
        {
            ToggleControls();
        }
        if (showOptions)
        {
            ToggleOptions();
        }
 
    }  
    public bool ToggleOptions()
    { 
        if(showOptions)
        {
            menu.SetActive(true);
            options.SetActive(false);
            showOptions = false;
            return false;
        }
        else
        {
            menu.SetActive(false);
            options.SetActive(true);
            showOptions = true;
            return true;
        }
    }
    public bool ToggleControls()
    {
        if (showControls)
        {
            options.SetActive(true);
            controls.SetActive(false);
            showControls = false;
            return false;
        }
        else
        {
            options.SetActive(false);
            controls.SetActive(true);
            showControls = true;
            return true;
        }
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("Volume",mainMusic.volume);
        PlayerPrefs.SetFloat("Brightness", brightness.intensity);
    }
    public void Load()
    {
        mainMusic.volume = PlayerPrefs.GetFloat("Volume");
        brightness.intensity = PlayerPrefs.GetFloat("Brightness");
    }
    
}
