using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    public static RunnerManager instance;

    public int highScore = 0;
    public int score = 0;
    public bool isDead;

    public bool gameStarted;

    public Transform roadSpawnPos;
    public float roadSpawnPosZ;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 0f;

    }

    private void Update()
    {
        if (isDead && gameStarted)
        {
            PlayerPrefs.SetInt("highScore", setScore());
            UIManager.instance.endGame();
        }
    }


    private int setScore()
    {
        if(score > highScore)
        {
            highScore = score;
        }

        score = 0;

        return highScore;
    }
}
