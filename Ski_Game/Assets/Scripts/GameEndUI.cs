using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Image crossfade;
    [SerializeField] private int nextLevelIndex = 1;
    [SerializeField] private LeaderboardUI leaderboardUI;

    public void Start()
    {
        gameOverMenu.SetActive(false);
        crossfade.CrossFadeAlpha(0, 1f, true);
    }

    private void OnEnable()
    {
        GameEvents.RaceFinish += EnableGameOver;
        GameEvents.Quit += Quit;
    }

    private void OnDisable()
    {
        GameEvents.RaceFinish -= EnableGameOver;
        GameEvents.Quit -= Quit;
    }

    private void EnableGameOver()
    {
        gameOverMenu.SetActive(true);
        leaderboardUI.UpdateLeaderboard(); 
    }

    public void QuitButton()
    {
        GameEvents.CallQuit();
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }
    
    private IEnumerator NextLevelCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }
    
    private IEnumerator QuitCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        Application.Quit();
    }


}

