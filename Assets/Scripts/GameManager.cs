using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float delayBeforeGameOverUI;
    public GameObject gameOverUI;
    public Text gameOverScore;
    private PlayerHorizontalMovement _playerHorizontalMovement;
    public string distance;
    
    //_playerHorizontalMovement.distance.ToString("0");

    public void Awake()
    {
        _playerHorizontalMovement = GameObject.Find("Player").GetComponent<PlayerHorizontalMovement>();
    }
    
    public void EndGame()
    {
        gameOverScore.text = _playerHorizontalMovement.distance.ToString("0");
        Invoke(nameof(SetGameOverUI), 1.5f);
    }
    
    private void SetGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
