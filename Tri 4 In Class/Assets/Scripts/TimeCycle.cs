using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeCycle : MonoBehaviour
{
    public enum TimeOfDay { Morning,Daytime,Afternoon,Night}
    

    public TimeOfDay timeOfDay;
    Light lightSource;
    public float transitionTime = 2f;

    [Header("Sky Colours")]
    public Color morningColor;
    public Color daytimeColor;
    public Color afternoonColor;
    public Color nightColor;

    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = TimeOfDay.Morning;
        lightSource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ChangeTime();
    }

    void ChangeTime()
    {
        if ((int)timeOfDay == System.Enum.GetValues(typeof(TimeOfDay)).Length -1)
            timeOfDay = 0;
        else
            timeOfDay++;

        switch (timeOfDay)
        {
            case TimeOfDay.Morning:
                lightSource.DOColor(morningColor, transitionTime);
                break;
            case TimeOfDay.Daytime:
                lightSource.DOColor(daytimeColor, transitionTime);
                break;
            case TimeOfDay.Afternoon:
                lightSource.DOColor(afternoonColor, transitionTime);
                break;
            case TimeOfDay.Night:
                lightSource.DOColor(nightColor, transitionTime);
                break;
        }
    }

}
