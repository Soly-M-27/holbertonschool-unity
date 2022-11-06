using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject MainCam;

    public GameObject player;

    // Update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause.activeInHierarchy)
            {
                Pause();
            }
            else if (pause.activeInHierarchy)
            {
                Resume();
            }
        }
    }

    // Activate Pause Menu
    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        player.GetComponent<Timer>().enabled = false;
        MainCam.GetComponent<CameraController>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
    }

    // Resume Game
    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        player.GetComponent<Timer>().enabled = true;
        MainCam.GetComponent<CameraController>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
    }

    // Restart Level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    // Go to Main Menu Scene
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    // Go to Options Menu Scene
    public void Options()
    {
        PlayerPrefs.SetInt("Previous", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Options");
        Resume();
    }
}