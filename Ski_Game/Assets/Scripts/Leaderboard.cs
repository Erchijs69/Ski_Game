using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = UnityEngine.PlayerPrefs;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
            bestTimes.Add(PlayerPrefs.GetFloat("time" + i, 99999));
        }
    }


    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveData();
    }

    private void SaveData()
    {
        for (int i = 0; i < 5; i++)
        {
            if(i< bestTimes.Count)
            PlayerPrefs.SetFloat("time"+i, bestTimes[i]);
        }
        PlayerPrefs.Save();
    }
}
