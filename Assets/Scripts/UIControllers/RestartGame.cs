using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        FindObjectOfType<PlayerLifeManager>().ResetPlayerHealth();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
