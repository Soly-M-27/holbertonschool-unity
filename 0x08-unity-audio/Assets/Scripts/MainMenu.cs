using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads level being chosen
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    // Helps load in the Options Menu
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Exits the Game Entirely
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
