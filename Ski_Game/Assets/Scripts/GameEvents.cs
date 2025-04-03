using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void RaceEvent();
    public static event RaceEvent RaceStart;
    public static event RaceEvent RacePenalty;
    public static event RaceEvent RaceFinish;
    public static event RaceEvent Quit;

    public static void CallQuit()
    {
        if (Quit != null)
            Quit();
    }

    public static void CallRaceStart()
    {
        if (RaceStart != null)
            RaceStart();
    }
    public static void CallRaceFinish()
    {
        if (RaceFinish != null)
            RaceFinish();
    }
    public static void CallRacePenalty()
    {
        if(RacePenalty != null)
            RacePenalty();
    }
    
    
}

