using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Screen Elements")]
    public bool showOptions;
    public int scrW, scrH;
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
    public int[] resX, resY;
    [Header("References")]
    public AudioSource mainMusic;
    public float volumeSlider;
    public Light brightness;
    public float brightnessSlider;

    void OnGUI()
    {
        if (!showOptions) // If we are in our menu
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(4*scrW, 0.25f*scrH, 8*scrW, 2*scrH), "Brain Exploders");
            // Buttons
            if (GUI.Button(new Rect(6*scrW, 4*scrH, 4*scrW, .5f * scrH), "Play"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(6*scrW, 5*scrH, 4*scrW, .5f * scrH), "Options"))
            {
                showOptions = !showOptions; // showOptions = true;
            }
            if (GUI.Button(new Rect(6*scrW, 6*scrH, 4*scrW, .5f * scrH), "Exit"))
            {
                Application.Quit();
            }
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

            GUI.Box(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f* scrH), scrW, 0.75f* scrH), "Volume");
            volumeSlider = GUI.HorizontalSlider(new Rect(2 * scrW, 3.25f* scrH + (i * 1f * scrH), 2f * scrW, 0.25f * scrH), volumeSlider, 0, 1);
            i++;
            GUI.Box(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f* scrH), scrW, 0.75f* scrH), "Brightness");
           brightnessSlider = GUI.HorizontalSlider(new Rect(2 * scrW, 3.25f * scrH + (i * .75f* scrH), 2f * scrW, 0.25f * scrH),brightnessSlider, 0, 1);


        }
    }

    // Use this for initialization
    void Start()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
