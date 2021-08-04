using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event Action LevelFinished;
    public event Action PlayerLost;

    private IDeath _snakeDeath;

    private void Awake() 
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void OnEnable() 
    {
        if(_snakeDeath == null)
        {
            Snake snake = FindObjectOfType<Snake>();
            _snakeDeath = snake.GetComponent<IDeath>();
        }

        _snakeDeath.IsDied += PlayerLose;
    }

    private void OnDisable()
    {
        _snakeDeath.IsDied -= PlayerLose;
    }

    public void FinishLevel()
    {
        LevelFinished?.Invoke();
    }

    public void PlayerLose()
    {
        PlayerLost?.Invoke();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
