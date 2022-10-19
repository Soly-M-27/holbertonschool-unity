using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private int next;
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        next = SceneManager.GetActiveScene().buildIndex + 1;
        total = SceneManager.sceneCountInBuildSettings - 1;   
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        if (next > total)
        {
            MainMenu();
        }
        else
        {
            SceneManager.LoadScene(next);
        }
    }
}
