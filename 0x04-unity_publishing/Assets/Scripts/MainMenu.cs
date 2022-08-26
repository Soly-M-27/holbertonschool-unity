using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Holds the Options Menu Scene
    public GameObject OptMenu;
    // Hold entire Main Menu Canvas
    public GameObject Menu;
    // Material trapMat
    public Material trapMat;
    // Material goalMat;
    public Material goalMat;
    // Toggle colorblindMode
    public Toggle colorblindMode;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Public methods to handle menu choices
    /// </summary>
    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color(255, 112, 0 , 1);
            goalMat.color = Color.blue;
            SceneManager.LoadScene("maze");
        }
        else
        {
            trapMat.color = new Color(255, 0, 0, 255);
            goalMat.color = new Color(0, 255, 0, 255);
            SceneManager.LoadScene("maze");
        }


    }

    /// <summary>
    /// Public method that quits the game
    /// </summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
    }
}
