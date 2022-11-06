using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //Var for toggle box
    public Toggle checkbox;
    
    // Start Game checking current scene and toggle settings
    public void Start()
    {
        if (PlayerPrefs.HasKey("InvertedYToggle"))
        {
            checkbox.isOn = (PlayerPrefs.GetInt("InvertedYToggle") == 1 ? true : false);
        }
    }

    // Load Back to Previous Scene Button
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Previous"));
    }
    // Apply Button
    public void Apply()
    {
        PlayerPrefs.SetInt("InvertedYToggle", checkbox.isOn ? 1 : 0);
    }
}
