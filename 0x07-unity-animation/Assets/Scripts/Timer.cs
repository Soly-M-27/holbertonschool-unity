using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    private float mins;
    private float secs;
    private float millisecs;
    private float mil;

    public GameObject Win_Screen;
    public TMP_Text FinalText_Time;

    // Start is called before the first frame update
    void Start()
    {
       mil = 0f;
       mins = 0f;
       secs = 0f;
       millisecs = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        mil += Time.deltaTime;

        mins = Mathf.FloorToInt(mil / 60);
        secs = Mathf.FloorToInt(mil % 60);
        millisecs = (mil % 1) * 100;

        TimerText.text = string.Format("{0:0}:{1:00}.{2:00}", mins, secs, millisecs);

        if (Win_Screen.activeInHierarchy)
        {
            Win();
        }
    }

    public void Win()
    {
        FinalText_Time.text = TimerText.text;
        TimerText.enabled = false;
        this.enabled = false;   
    }
}
