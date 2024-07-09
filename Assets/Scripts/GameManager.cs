using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private float gameSpeed;
    private Scene currentScene;
    private int score;

    public float GameSpeed
    {
        get => gameSpeed;
        set => gameSpeed = value;
    }
    public int Score { get => score; }


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

    public void Defeat()
    {
        if (!(currentScene.name == "Main Scene")) return;

        GameSpeed = 0;
        SceneManager.LoadScene("Game Over Scene");
    }

    public void StartGame()
    {
        if (!(currentScene.name == "Start Scene")) return;

        SceneManager.LoadScene("Main Scene");
    }
}
