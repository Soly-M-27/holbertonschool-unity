using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public Text TimerText;

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<Timer>.enabled = false;
        TimerText.color = Color.green;
        TimerText.fontSize = 60;
    }
}
