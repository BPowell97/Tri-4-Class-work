using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeCycle : MonoBehaviour
{
    public enum TimeOfDay { MorningTime,DayTime,EveningTime,NightTime}
    

    public TimeOfDay timeOfDay;
    Light lightSource;
    public float transitionTime = 2f;
    public bool RandomTime;

    [Header("Timers")]
    public int currentTime;
    public float timeModifier = 1;
    bool stopped;



    [Header("Sky Colours")]
    public Color morningColor;
    public Color daytimeColor;
    public Color afternoonColor;
    public Color nightColor;

    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = TimeOfDay.MorningTime;
        lightSource = GetComponent<Light>();
        currentTime = 0;
        StartCoroutine(TickToc());
        //Debug.Log(Utilities.EnumLength(timeOfDay));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ChangeTime();
        if (Input.GetKeyDown(KeyCode.R))
            ChangeTime();
    }

    void ChangeTime()
    {

        if (RandomTime)
        {
            timeOfDay = Utilities.RandomEnumValue<TimeOfDay>();
        }
        else
        {
            //if 
        }

        if ((int)timeOfDay == Utilities.EnumLength(timeOfDay))
            timeOfDay = 0;
        else
            timeOfDay++;

        Debug.Log(Utilities.EnumToString(timeOfDay));


        switch (timeOfDay)
        {
            case TimeOfDay.MorningTime:
                lightSource.DOColor(morningColor, transitionTime);
                break;
            case TimeOfDay.DayTime:
                lightSource.DOColor(daytimeColor, transitionTime);
                break;
            case TimeOfDay.EveningTime:
                lightSource.DOColor(afternoonColor, transitionTime);
                break;
            case TimeOfDay.NightTime:
                lightSource.DOColor(nightColor, transitionTime);
                break;
        }
    }


    IEnumerator TickToc()
    {
        while (!stopped)
        {
            yield return new WaitForSeconds(timeModifier);
            if (currentTime == 23)
                currentTime = 0;
            else
                currentTime++;
        }
       
    }

}
