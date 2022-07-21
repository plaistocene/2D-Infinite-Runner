using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float delayBeforeRestart = 2f;
    public GameObject levelCompleteUI;
    public GameObject gameOverUI;
    public Text gameOverScore;
    private PlayerHorizontalMovement _playerHorizontalMovement;
    
    private bool _gameRunning = true;

    public void Awake()
    {
        _playerHorizontalMovement = GameObject.Find("Player").GetComponent<PlayerHorizontalMovement>();
    }

    public void CompleteLevel()
    {
        FindObjectOfType<PlayerDisableMovement>().DisableMovement();
        levelCompleteUI.SetActive(true);
    }
    public void EndGame()
    {
        if (!_gameRunning) return;
        _gameRunning = false;
        gameOverScore.text = _playerHorizontalMovement.distance.ToString("0");
        gameOverUI.SetActive(true);
        // Invoke(nameof(Restart), delayBeforeRestart);
    }
}
