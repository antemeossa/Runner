using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    public static RunnerManager instance;

    public int score = 0;

    public bool isDead;

    public bool gameStarted;

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
}
