using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float delayAfterCharacterDeath = 1.5f;
    public GameObject gameOverUI;
    public Text gameOverScore;
    private PlayerHorizontalMovement _playerHorizontalMovement;
    
    //_playerHorizontalMovement.distance.ToString("0");

    public void Awake()
    {
        _playerHorizontalMovement = GameObject.Find("Player").GetComponent<PlayerHorizontalMovement>();
    }
    
    public void GameOver()
    {
        gameOverScore.text = _playerHorizontalMovement.distance.ToString("0");
        
        Invoke(nameof(SetGameOverUI), delayAfterCharacterDeath);
    }
    
    private void SetGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        Invoke(nameof(RestartLevel), delayAfterCharacterDeath);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
