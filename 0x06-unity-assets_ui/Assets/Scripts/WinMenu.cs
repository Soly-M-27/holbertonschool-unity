using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private int Next;
    private int Total;

    // Start is called before the first frame update
    void Start()
    {
        Next = SceneManager.GetActiveScene().buildIndex + 1;
        Total = SceneManager.sceneCountInBuildSettings - 1;   
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        if (Next > Total)
        {
            MainMenu();
        }
        else
        {
            SceneManager.LoadScene(Next);
        }
    }
}
