using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    private bool timerRunning = false;

    private void OnEnable()
    {
        GameEvents.raceStart += StartRace;
        GameEvents.raceEnd += FinishRace;
    }

    private void OnDisable()
    {
        GameEvents.raceStart -= StartRace;
        GameEvents.raceEnd -= FinishRace;
    }

    private void StartRace()
    {
        timerRunning = true;
        Debug.Log("Race started");
    }

    private void FinishRace()
    {
        timerRunning = false;
        Debug.Log("Race finished");
    }
}
