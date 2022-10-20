using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;
    public GameObject MainCam;
    public GameObject TimeCanvas;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("MainCamera"))
        {
            CutsceneCameraTrig();       
        }
    }

    public void CutsceneCameraTrig()
    {
        MainCam.SetActive(true);
        TimeCanvas.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
