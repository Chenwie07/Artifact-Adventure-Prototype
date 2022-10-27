using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

public class GameManager : MonoBehaviour
{
    public Flowchart flowchart; 
    public static GameManager Instance;

    [Header("Spawner")]
    public GameObject _orbSpawnPrefab;
    public Transform[] spawnLocation;

    [Header("UI Elements")]
    public GameObject GameOverPanel;
    public TMPro.TextMeshProUGUI OrbsCount;
    public TMPro.TextMeshProUGUI ObjectiveText;
    public TMPro.TextMeshProUGUI ChallengeCountdownTimer;

    internal void AddTime()
    {

        currentTime -= 5;
        if (currentTime < 0)
            currentTime = 0; 
    }

    private int _orbsCollected;

    private bool _timeUp;
    private bool _startTimer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _timeUp = false;
        _orbsCollected = 0;
    }
    public void CallOrbs()
    {
        _startTimer = true;
        foreach (var location in spawnLocation)
        {
            Instantiate(_orbSpawnPrefab, location.position, Quaternion.identity, location);
        }
    }
    internal void UpdatePickUp()
    {
        _orbsCollected++;
        if (_orbsCollected >= 7 && !_timeUp) // hard coding for illustrative purposes 
        {
            _startTimer = false; 
            ObjectiveText.SetText("Return to temple voice");
            flowchart.ExecuteBlock("Notify3"); 
        }
        UpdateOrbsCount();
    }
    private void UpdateOrbsCount()
    {
        OrbsCount.SetText(_orbsCollected.ToString());
    }
    private float challengeTime = 45f;
    private float currentTime = 0;


    // Update. 
    private void Update()
    {
        if (!_startTimer)
            return;

        if (_timeUp == false)
        {
            currentTime += Time.deltaTime;
            ChallengeCountdownTimer.SetText("Time left: " + Mathf.Round(challengeTime - currentTime).ToString());
        }
        if (currentTime > challengeTime && _orbsCollected < 7)
        {
            _timeUp = true;
            // call method to restart
            GameOverPanel.SetActive(true);
        }
    }

    public void SetTimeRunning()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
}
