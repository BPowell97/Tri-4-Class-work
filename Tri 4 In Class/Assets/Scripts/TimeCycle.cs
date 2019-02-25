using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum TimeOfDay { MorningTime, DayTime, EveningTime, NightTime }

public class TimeCycle : MonoBehaviour
{
    //public enum TimeOfDay { MorningTime,DayTime,EveningTime,NightTime}
    

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
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ChangeTime();
        if (Input.GetKeyDown(KeyCode.R))
            ChangeTime();
    }*/

    void ChangeTime()
    {
        #region Old time stuff
        /*if (RandomTime)
        {
            timeOfDay = Utilities.RandomEnumValue<TimeOfDay>();
        }
        else
        {
            //if ((int )) 
        }

        if ((int)timeOfDay == Utilities.EnumLength(timeOfDay))
            timeOfDay = 0;
        else
            timeOfDay++;

        Debug.Log(Utilities.EnumToString(timeOfDay));*/
        #endregion

        timeOfDay = GetTimeOfDay();

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

        GameEvents.ReportOnTimeOfDayChanged(timeOfDay);
    }

    TimeOfDay GetTimeOfDay()
    {
        switch (currentTime)
        {
            case 0: 
            case 1:
            case 2:  
            case 3:
                return TimeOfDay.NightTime;
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                return TimeOfDay.MorningTime;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
                return TimeOfDay.DayTime;
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
                return TimeOfDay.NightTime;
            default:
                return TimeOfDay.NightTime;


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

            ChangeTime();
        }
       
    }

}
