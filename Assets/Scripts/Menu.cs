﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Screen Elements")]
    public bool showOptions;
    public int scrW, scrH;
    public bool fullScreenToggle;
    [Header("Keys")]
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode crouch;
    public KeyCode interact;
    public KeyCode sprint;
    public KeyCode melee;
    public KeyCode shoot;
    public KeyCode holdingKey;
    [Header("Resolutions")]
    public int index;
    public bool showRes;
    public int[] resX, resY;
    private Vector2 scrollPosRes;
    [Header("References")]
    public AudioSource mainMusic;
    public float volumeSlider;
    public Light brightness;
    public float brightnessSlider;
    public float holdingVolume;
    public bool muteToggle;
    [Header("Art")]
    public GUISkin menuSkin;
    public GUIStyle boxStyle;

    public void Forward()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = forward;
            // Set this button to none allowing us to edit only this button
            forward = KeyCode.None;
            // Set the GUI to blank
            //forwardText.text = forward.ToString();
        }
    }

    void OnGUI()
    {



        if (!showOptions) // If we are in our menu
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", boxStyle);
            GUI.skin = menuSkin;
            GUI.Box(new Rect(0 * scrW, 0.25f * scrH, 8 * scrW, 2 * scrH), "Brain Exploders");
            // Buttons
            if (GUI.Button(new Rect(2 * scrW, 3 * scrH, 4 * scrW, .75f * scrH), "Play"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(2 * scrW, 4 * scrH, 4 * scrW, .75f * scrH), "Options"))
            {
                showOptions = !showOptions; // showOptions = true;
            }

            if (GUI.Button(new Rect(2 * scrW, 5 * scrH, 4 * scrW, .75f * scrH), "Exit"))
            {
                Application.Quit();
            }
            GUI.skin = null;
        }
        if (showOptions) // If we are in options
        {
            if (scrW != Screen.width)
            {
                scrW = Screen.width / 16;
                scrH = Screen.height / 9;
            }
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//background box
            int i = 0;
            GUI.Box(new Rect(4 * scrW, 0.25f * scrH, 8 * scrW, 2 * scrH), "Options");//Title

            GUI.Box(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f * scrH), 2 * scrW, 0.5f * scrH), "Volume");
            volumeSlider = GUI.HorizontalSlider(new Rect(3 * scrW, 3.25f * scrH + (i * 1f * scrH), 2f * scrW, 0.25f * scrH), volumeSlider, 0, 1);

            if (GUI.Button(new Rect(9.5f * scrW, 3f * scrH + (i * (scrH * 0.5f)), 1.5f * scrW, 0.5f * scrH), "Up"))
            {
                Event e = Event.current;
                if (forward == KeyCode.None)
                {
                    // If an event is triggered by a key press
                    if (e.isKey)
                    {
                        Debug.Log("Key Code" + e.keyCode);
                        // If the key is not the same as the other ones
                        if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right))
                        {
                            // Set forward to the new key
                            forward = e.keyCode;
                            // Set holding key to none
                            holdingKey = KeyCode.None;
                            // Set to new Key

                        }
                        else
                        {
                            // Set forward back to what the holding key is
                            forward = holdingKey;
                            // Set holding key to none
                            holdingKey = KeyCode.None;
                            // Set back to last key

                        }
                    }                    
                }
            }

            if (GUI.Button(new Rect(9.5f * scrW, 4f * scrH + (i * (scrH * 0.5f)), 1.5f * scrW, 0.5f * scrH), "Down"))
            {

            }

            if (GUI.Button(new Rect(8.75f * scrW, 3.5f * scrH + (i * (scrH * 0.5f)), 1.5f * scrW, 0.5f * scrH), "Left"))
            {

            }

            if (GUI.Button(new Rect(10.25f * scrW, 3.5f * scrH + (i * (scrH * 0.5f)), 1.5f * scrW, 0.5f * scrH), "Right"))
            {

            }

            if (GUI.Button(new Rect(14.5f * scrW, 8.5f * scrH + (i * (scrH * 0.5f)), 1.5f * scrW, 0.5f * scrH), "Back"))
            {
                showOptions = false;
            }
            if (GUI.Button(new Rect(5.75f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.5f * scrW, 0.5f * scrH), "Mute")) // Label
            {
                ToggleVolume();
            }

            i++;
            GUI.Box(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f * scrH), 2 * scrW, 0.5f * scrH), "Brightness");
            brightnessSlider = GUI.HorizontalSlider(new Rect(3 * scrW, 3.25f * scrH + (i * .75f * scrH), 2f * scrW, 0.25f * scrH), brightnessSlider, 0, 1);

            #region Resoulution and Screen
            i++;
            if (GUI.Button(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f * scrH), 2 * scrW, 0.5f * scrH), "Resolutions"))
            {
                showRes = !showRes;
            }

            if (GUI.Button(new Rect(2.5f * scrW, 3 * scrH + (i * 0.75f * scrH), 1.75f * scrW, 0.5f * scrH), "FullScreen"))
            {
                FullScreenToggle();
            }
            i++;
            if (showRes)
            {
                GUI.Box(new Rect(.5f * scrW, 3.5f * scrH + (i * (scrH * 0.5f)), 2f * scrW, 3f * scrH), "");

                scrollPosRes = GUI.BeginScrollView(new Rect(0.75f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 3.5f * scrH), scrollPosRes, new Rect(0, 0, 1.75f * scrW, 3.5f * scrH));

                for (int resSize = 0; resSize < resX.Length; resSize++)
                {
                    if (GUI.Button(new Rect(-.25f * scrW, .5f * scrH + resSize * (scrH * 0.5f), 2f * scrW, 0.5f * scrH), resX[resSize].ToString() + "x" + resY[resSize].ToString()))
                    {
                        Screen.SetResolution(resX[resSize], resY[resSize], fullScreenToggle);
                        showRes = false;
                    }
                }
                GUI.EndScrollView();
            }
            #endregion

        }
    }

    bool ToggleVolume()
    {
        if (muteToggle == true)
        {
            muteToggle = false;
            volumeSlider = holdingVolume;
            return false;
        }
        else
        {
            muteToggle = true;
            holdingVolume = volumeSlider;
            volumeSlider = 0;
            mainMusic.volume = 0;
            return true;
        }
    }



    bool FullScreenToggle()
    {
        if (fullScreenToggle)
        {
            fullScreenToggle = false;
            Screen.fullScreen = false;
            return false;
        }
        else
        {
            fullScreenToggle = true;
            Screen.fullScreen = true;
            return true;
        }
    }

    // Use this for initialization
    void Start()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;
        fullScreenToggle = true;

        brightness = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();
        mainMusic = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        volumeSlider = mainMusic.volume;
        brightnessSlider = brightness.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMusic != null)
        {
            if (muteToggle == false)
            {
                if (mainMusic.volume != volumeSlider)
                {
                    holdingVolume = volumeSlider;
                    mainMusic.volume = volumeSlider;
                }
            }
            else
            {
                volumeSlider = 0;
                mainMusic.volume = 0;
            }
        }

        if (brightness != null)
        {
            if (brightnessSlider != brightness.intensity)
            {
                brightness.intensity = brightnessSlider;
            }
        }
    }
}
