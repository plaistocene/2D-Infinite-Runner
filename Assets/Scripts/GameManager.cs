using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float delayBeforeRestart = 2f;
    public GameObject levelCompleteUI;
    
    private bool _gameRunning = true;

    public void CompleteLevel()
    {
        FindObjectOfType<PlayerDisableMovement>().DisableMovement();
        levelCompleteUI.SetActive(true);
    }
    public void EndGame()
    {
        if (!_gameRunning) return;
        _gameRunning = false;
        Invoke(nameof(Restart), delayBeforeRestart);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
