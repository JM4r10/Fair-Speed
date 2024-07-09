using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Scene currentScene;

    [SerializeField] private float gameSpeed;
    private float minSpeed = 5f;
    private float score;
    private float fixedScoreIncrease = 0.01f;
    private float fixedSpeedDecrease = 0.05f;

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
    }

    private void FixedUpdate()
    {
        score += fixedScoreIncrease * gameSpeed;

        if (gameSpeed < minSpeed)
        {
            gameSpeed = minSpeed;
        }
        else
        {
            gameSpeed -= fixedSpeedDecrease;
        }
    }
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
