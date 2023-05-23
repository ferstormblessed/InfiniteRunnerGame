using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;

    public static GameManager Instance
    {
        get => _gameManager;
        set => _gameManager = value;
    }

    [SerializeField] private UIController _uiController;

    private int _coinCounter = 0;

    public int CoinCounter
    {
        get => _coinCounter;
        set => _coinCounter = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private bool _gameOver;
    public bool GameOver
    {
        get => _gameOver;
        set
        {
            _gameOver = value;
            _uiController.ShowGameOverScren();
        }
    }
    
    public void ReloadGame()
    {
        SceneManager.LoadScene("InfiniteRunner");
    }
}
