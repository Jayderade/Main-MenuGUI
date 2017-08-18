using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    [Header("Bools")]
    public bool showControls;
    public bool showOptions;
    public bool showPauseOptions;
    public bool showPauseControls;
    // setting bool true or false
    public bool fullscreen;
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
    [Header("References")]
    public GameObject menu;
    public GameObject controls;
    public GameObject options;
    public GameObject pauseOptions;
    public GameObject pauseControls;
    public AudioSource mainMusic;
    public Slider volumeSlider, brightnessSlider;
    public Light brightness;
    public Text forwardText, backwardText, leftText, rightText, jumpText, crouchText, sprintText, meleeText, shootText, interactText;
    // Setting toggle field to "fullscreen"
    public Toggle fullScreen;
    public Toggle mute;
    // setting dropdown field to "resolution"
    public Dropdown resolution;
    void Start()
    {
        // makes build fullscreen
        fullscreen = true;
        // setting the resolution
        Screen.SetResolution(640, 480, false);
        Screen.SetResolution(1024, 575, false);
        Screen.SetResolution(1280, 720, false);
        Screen.SetResolution(1600, 900, false);
        Screen.SetResolution(1920, 1080, false);
        Screen.SetResolution(2560, 1440, false);
        Screen.SetResolution(3840, 2160, false);
        Screen.SetResolution(7680, 4800, false);
        Screen.SetResolution(1600, 1000, true);


        if (mainMusic != null && volumeSlider != null)
        {
            if (PlayerPrefs.HasKey("Volume"))
            {
                Load();
            }
            volumeSlider.value = mainMusic.volume;
        }
        if (brightness != null && brightnessSlider != null)
        {
            brightnessSlider.value = brightness.intensity;
        }
        
        #region Key Set Up
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "LeftControl"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift"));
        shoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shoot", "Mouse0"));
        melee = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Melee", "Mouse1"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "LeftAlt"));

        forwardText.text = forward.ToString();
        backwardText.text = backward.ToString();
        leftText.text = left.ToString();
        rightText.text = right.ToString();
        crouchText.text = crouch.ToString();
        jumpText.text = jump.ToString();
        sprintText.text = sprint.ToString();
        interactText.text = interact.ToString();
        shootText.text = shoot.ToString();
        meleeText.text = melee.ToString();
        #endregion
    }
    void Update()
    {
        if (volumeSlider.value != mainMusic.volume)
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
        if (showOptions)
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
        PlayerPrefs.SetFloat("Volume", mainMusic.volume);
        PlayerPrefs.SetFloat("Brightness", brightness.intensity);
        PlayerPrefs.SetString("Forward", forward.ToString());
        PlayerPrefs.SetString("Backward", backward.ToString());
        PlayerPrefs.SetString("Jump", jump.ToString());
        PlayerPrefs.SetString("Crouch", crouch.ToString());
        PlayerPrefs.SetString("Sprint", sprint.ToString());
        PlayerPrefs.SetString("Left", left.ToString());
        PlayerPrefs.SetString("Right", right.ToString());
        PlayerPrefs.SetString("Interact", interact.ToString());
        PlayerPrefs.SetString("Melee", melee.ToString());
        PlayerPrefs.SetString("Shoot", shoot.ToString());
        PlayerPrefs.SetInt("640 x 480", 
    }
    public void Load()
    {
        mainMusic.volume = PlayerPrefs.GetFloat("Volume");
        brightness.intensity = PlayerPrefs.GetFloat("Brightness");
        forwardText.text = PlayerPrefs.GetString("Forward");
        backwardText.text = PlayerPrefs.GetString("Backward");
        leftText.text = PlayerPrefs.GetString("Left");
        rightText.text = PlayerPrefs.GetString("Right");
        jumpText.text = PlayerPrefs.GetString("Jump");
        crouchText.text = PlayerPrefs.GetString("Crouch");
        sprintText.text = PlayerPrefs.GetString("Sprint");
        interactText.text = PlayerPrefs.GetString("Interact");
        meleeText.text = PlayerPrefs.GetString("Melee");
        shootText.text = PlayerPrefs.GetString("Shoot");
    }
    public void ScreenToggle()// Name the function "ScreenToggle"
    {
        // Once enabled it flips
        Screen.fullScreen = !Screen.fullScreen;
        // Ensures ScreenToggle works with fullscreen bool
        fullscreen = !fullscreen;
    }
    void OnGUI()
    {
        #region Set New Key or Set Key Back
        Event e = Event.current;
        if (forward == KeyCode.None)
        {
            // If an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                // If the key is not the same as the other ones
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == jump || e.keyCode == interact || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    forward = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    forwardText.text = forward.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    forward = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    forwardText.text = forward.ToString();
                }
            }
       
            
        }
        
        if (backward == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == jump || e.keyCode == interact || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    backward = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    backwardText.text = backward.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    backward = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    backwardText.text = backward.ToString();
                }
            }
          

        }
        if (left == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == forward || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == jump || e.keyCode == interact || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    left = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    leftText.text = left.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    left = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    leftText.text = left.ToString();
                }
            }
          

        }
        if (right == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == forward || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == jump || e.keyCode == interact || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    right = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    rightText.text = right.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    right = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    rightText.text = right.ToString();
                }
            }
         

        }
        if (crouch == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == forward || e.keyCode == sprint || e.keyCode == jump || e.keyCode == interact || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    crouch = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    crouchText.text = crouch.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    crouch = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    crouchText.text = crouch.ToString();
                }
            }
           

        }
        if (sprint == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == crouch || e.keyCode == forward || e.keyCode == jump || e.keyCode == interact || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    sprint = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    sprintText.text = sprint.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    sprint = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    sprintText.text = sprint.ToString();
                }
            }
          

        }
        if (jump == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == forward || e.keyCode == interact || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    jump = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    jumpText.text = jump.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    jump = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    jumpText.text = jump.ToString();
                }
            }
            

        }
        if (interact == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == jump || e.keyCode == forward || e.keyCode == melee || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    interact = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    interactText.text = interact.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    interact = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    interactText.text = interact.ToString();
                }
            }
           

        }
        if (melee == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == jump || e.keyCode == interact || e.keyCode == forward || e.keyCode == shoot))
                {
                    // Set forward to the new key
                    melee = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    meleeText.text = melee.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    melee = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    meleeText.text = melee.ToString();
                }
            }
           

        }
        if (shoot == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == jump || e.keyCode == interact || e.keyCode == melee || e.keyCode == forward))
                {
                    // Set forward to the new key
                    shoot = e.keyCode;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set to new Key
                    shootText.text = shoot.ToString();
                }
                else
                {
                    // Set forward back to what the holding key is
                    shoot = holdingKey;
                    // Set holding key to none
                    holdingKey = KeyCode.None;
                    // Set back to last key
                    shootText.text = shoot.ToString();
                }
            }
         

        }

        #endregion
    }
    #region Controls
    public void Forward()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = forward;
            // Set this button to none allowing us to edit only this button
            forward = KeyCode.None;
            // Set the GUI to blank
            forwardText.text = forward.ToString();
        }
    }
    public void Backward()
    {
        if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = backward;
            // Set this button to none allowing us to edit only this button
            backward = KeyCode.None;
            // Set the GUI to blank
            backwardText.text = backward.ToString();
        }
    }
    public void Left()
    {
        if (!(backward == KeyCode.None || forward == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = left;
            // Set this button to none allowing us to edit only this button
            left = KeyCode.None;
            // Set the GUI to blank
            leftText.text = left.ToString();
        }
    }
    public void Right()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || forward == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = right;
            // Set this button to none allowing us to edit only this button
            right = KeyCode.None;
            // Set the GUI to blank
            rightText.text = right.ToString();
        }
    }
    public void Crouch()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || forward == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = crouch;
            // Set this button to none allowing us to edit only this button
            crouch = KeyCode.None;
            // Set the GUI to blank
            crouchText.text = crouch.ToString();
        }
    }
    public void Sprint()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || forward == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = sprint;
            // Set this button to none allowing us to edit only this button
            sprint = KeyCode.None;
            // Set the GUI to blank
            sprintText.text = sprint.ToString();
        }
    }
    public void Jump()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || forward == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = jump;
            // Set this button to none allowing us to edit only this button
            jump = KeyCode.None;
            // Set the GUI to blank
            jumpText.text = jump.ToString();
        }
    }
    public void Interact()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || forward == KeyCode.None || melee == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = interact;
            // Set this button to none allowing us to edit only this button
            interact = KeyCode.None;
            // Set the GUI to blank
            interactText.text = interact.ToString();
        }
    }
    public void Melee()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || forward == KeyCode.None || shoot == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = melee;
            // Set this button to none allowing us to edit only this button
            melee = KeyCode.None;
            // Set the GUI to blank
            meleeText.text = melee.ToString();
        }
    }
    public void Shoot()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || jump == KeyCode.None || interact == KeyCode.None || melee == KeyCode.None || forward == KeyCode.None))
        {
            // Set our holding key to the key of this button
            holdingKey = shoot;
            // Set this button to none allowing us to edit only this button
            shoot = KeyCode.None;
            // Set the GUI to blank
            shootText.text = shoot.ToString();
        }
    }
    #endregion
    public void Resolution()// Named the function "Resolution"
    {
        // References the Option names in the dropdown component
        switch (resolution.captionText.text)
        {
            // Each case name matches each option name and displays resolution
            case "640 x 480":
                Screen.SetResolution(640, 480, fullscreen);
                break;
            case "1024 x 575":
                Screen.SetResolution(1024, 575, fullscreen);
                break;
            case "1280 x 720":
                Screen.SetResolution(1280, 720, fullscreen);
                break;
            case "1600 x 900":
                Screen.SetResolution(1600, 900, fullscreen);
                break;
            case "1920 x 1080":
                Screen.SetResolution(1920, 1080, fullscreen);
                break;
            case "2560 x 1440":
                Screen.SetResolution(2560, 1440, fullscreen);
                break;
            case "3840 x 2160":
                Screen.SetResolution(3840, 2160, fullscreen);
                break;
            case "7680 x 4800":
                Screen.SetResolution(7680, 4800, fullscreen);
                break;
            // This is the default set resolution
            default:
                Screen.SetResolution(1600, 1000, fullscreen);
                    break;
        }
    }
}
