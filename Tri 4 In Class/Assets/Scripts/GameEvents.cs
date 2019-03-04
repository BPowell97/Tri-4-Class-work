using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{

    public static event Action<TimeOfDay> OnTimeOfDayChanged = null;
    public static event Action<int, int> OnTimerChanged = null;
    public static event Action OnTimerUp = null;

    public static void ReportOnTimeOfDayChanged(TimeOfDay timeOfDay)
    {
        if (OnTimeOfDayChanged != null)
            OnTimeOfDayChanged(timeOfDay);
    }

    public static void ReportOnTimerChanged (int minutes, int seconds)
    {
        if (OnTimerChanged != null)
            OnTimerChanged(minutes, seconds);
    }

    public static void ReportOnTimerUp()
    {
        if (OnTimerUp != null)
            OnTimerUp();
    }

}
