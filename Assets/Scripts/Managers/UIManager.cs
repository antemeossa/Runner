using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text score;
    public Text highScore;
    public Canvas startScreen;
    public Canvas pauseScreen;
    public Canvas endScreen;
    public Text projectileCount;
    public int projectileInt = 0;


    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        startScreen.enabled = true;
        pauseScreen.enabled = false;
        endScreen.enabled = false;

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


    

    // Update is called once per frame
    void Update()
    {
        UIscore();
        projectileText();
    }

    public void startGame()
    {
        Time.timeScale = 1f;
        startScreen.enabled=false;
        RunnerManager.instance.gameStarted = true;
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.enabled = true;


    }

    public void contiuneGame()
    {
        Time.timeScale = 1f;
        pauseScreen.enabled = false;
    }

    public void endGame()
    {
        endScreen.enabled = true;
        highScore.text = "High Score: " + RunnerManager.instance.highScore;
        RunnerManager.instance.gameStarted = false;

    }

    public void UIscore()
    {
        score.text = "Score: " + RunnerManager.instance.score;
    }

    public void retry()
    {
        endScreen.enabled = false;

        SceneManager.LoadScene(0);

        startScreen.enabled = true;
        RunnerManager.instance.isDead = false;

    }
    
    private void projectileText()
    {
        projectileCount.text = "Projectile Count: " + projectileInt;
    }

}
