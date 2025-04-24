using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] timeTexts;

    private void OnEnable()
    {
        UpdateLeaderboard();
    }

    public void UpdateLeaderboard()
    {
        for (int i = 0; i < timeTexts.Length; i++)
        {
            float time = PlayerPrefs.GetFloat("time" + i, 99999);
            timeTexts[i].text = FormatTime(time);
        }
    }

    private string FormatTime(float time)
    {
        if (time >= 99999) return "--:--.---";
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time % 1) * 1000);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}


