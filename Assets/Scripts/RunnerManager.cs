using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{

    public static bool gameOver;

    public static bool isGameStarted;

    public static int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Time.timeScale = 1;

        gameOver = isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }

        //start game

        if (!isGameStarted)
        {
            isGameStarted = true;
        }
    }
}
