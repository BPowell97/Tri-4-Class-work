using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timeLeft = 60.0f;
    public bool stop = true;

    private float minutes;
    private float seconds;
    

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            timeLeft -= Time.deltaTime;

            minutes = Mathf.Floor(timeLeft / 60);
            seconds = timeLeft % 60;
            GameEvents.ReportOnTimerChanged((int)minutes, (int)seconds);
            if (seconds > 59) seconds = 59;
            if (minutes < 0)
            {
                stop = true;
                minutes = 0;
                seconds = 0;
                GameEvents.ReportOnTimerUp();
            }

            

        }
    }
}
