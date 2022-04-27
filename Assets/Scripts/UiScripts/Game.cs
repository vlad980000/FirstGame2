using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameoverScreen _overScreen;
    [SerializeField] private Spawner[] _spawns;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _overScreen.RestartButtonClick += OnRestartButtonClick;
        _player.Gameover += OnGameover; 
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _overScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.Gameover -= OnGameover;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _overScreen.Close();
        RestartSpawns();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        RestartSpawns();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.RestartPlayer();
    }

    private void RestartSpawns()
    {
        foreach (var item in _spawns)
        {
            item.ResetPool();
        }
    }

    public void OnGameover()
    {
        Time.timeScale = 0;
        _overScreen.Open();
    }
}
