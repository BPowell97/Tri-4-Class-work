using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerListener : MonoBehaviour
{
    TextMeshProUGUI timer;
    TextMeshPro characterTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<TextMeshProUGUI>() != null)
            timer = GetComponent<TextMeshProUGUI>();

        if(GetComponent<TextMeshPro>() != null)
            characterTimer = GetComponent<TextMeshPro>();
        
    }

    private void OnEnable()
    {
        GameEvents.OnTimerChanged += OnTimerChanged;
        GameEvents.OnTimerUp += OnTimerUp;
    }

    private void OnDisable()
    {
        GameEvents.OnTimerChanged -= OnTimerChanged;
        GameEvents.OnTimerUp -= OnTimerUp;
    }

    void OnTimerChanged(int minutes, int seconds)
    {
        if (timer != null)
            timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        if(characterTimer != null)
            characterTimer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        
    }

    void OnTimerUp()
    {
        string timeUpMessage = "Time Up";
        if (timer != null)
            timer.text = timeUpMessage;
        if (characterTimer != null)
            characterTimer.text = timeUpMessage;
    }
}
