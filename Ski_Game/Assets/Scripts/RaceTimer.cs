using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    bool timerRunning = false;
    private float raceTime = 0;
    [SerializeField] private Leaderboard leaderboard;
    private void OnEnable()
    {
        GameEvents.RaceStart += StartRaceTimer;
        GameEvents.RaceFinish += StopRaceTimer;
        GameEvents.RacePenalty += RacePenalty;
    }
    private void OnDisable()
    {
        GameEvents.RaceStart -= StartRaceTimer;
        GameEvents.RaceFinish -= StopRaceTimer;
        GameEvents.RacePenalty -= RacePenalty;
    }
    private void Update()
    {
        if (timerRunning)
            raceTime += Time.deltaTime;
    }
    private void RacePenalty()
    {
        raceTime += 1;
        Debug.Log("penalty recieved");
    }


    private void StartRaceTimer()
    {
        raceTime = 0;
        timerRunning = true;
        Debug.Log("race started");
    }
    private void StopRaceTimer()
    {
        timerRunning = false;
        leaderboard.AddTime(raceTime);
        GameData.Instance.racesCompleted++;
        Debug.Log("Races completed" + GameData.Instance.racesCompleted);
        Debug.Log("Race finished! Race time: "+ raceTime);
    }
}

