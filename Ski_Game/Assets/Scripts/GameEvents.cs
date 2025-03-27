using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
   public delegate void RaceEvent();

   public static event RaceEvent raceStart;
   public static event RaceEvent raceEnd;
   public static event RaceEvent racePenalty;

   public static void CallRaceStart()
   {
    if (raceStart != null)
    {
        raceStart();
    }
   }

}
