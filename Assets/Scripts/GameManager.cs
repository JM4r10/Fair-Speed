using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Scene currentScene;

    [SerializeField] private float gameSpeed;
    [SerializeField] private int updateInterval;
    private float score;
    private readonly float minSpeed = 5f;
    private readonly float fixedScoreIncrease = 0.1f;
    private readonly float fixedSpeedDecrease = 0.5f;

    public float GameSpeed
    {
        get => gameSpeed;
        set => gameSpeed = value;
    }
    public float Score { get => score; }


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        StartCoroutine(StatsUpdate());
    }

   
    private IEnumerator StatsUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);
            ScoreUpdate();
            SpeedUpdate();
        }
    }

    private void SpeedUpdate()
    {
        if (gameSpeed < minSpeed)
        {
            gameSpeed = minSpeed;
        }
        else
        {
            gameSpeed -= fixedSpeedDecrease;
        }
    }

    private void ScoreUpdate() => score += fixedScoreIncrease * gameSpeed;

    public void Defeat()
    {
        if (!(currentScene.name == "Main Scene")) return;

        gameSpeed = 0;
        SceneManager.LoadScene("Game Over Scene");
    }

    public void StartGame()
    {
        if (!(currentScene.name == "Start Scene")) return;

        score = 0;
        SceneManager.LoadScene("Main Scene");
    }
}
