using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private AudioManager _audioManager;
    public GameObject playerDestruction;

    private PlayerLifeManager _playerLifeManager;
    private int _playerLives;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _playerLifeManager = FindObjectOfType<PlayerLifeManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Hostile"))
        {
            FindObjectOfType<PlayerDisableMovement>().DisableMovement();

            InstantiatePlayerDestruction();

            _audioManager.Play("Death");
            
            _playerLives = _playerLifeManager.ReducePlayerLivesByOne();

            if (_playerLives <= 0)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
            else
            {
                FindObjectOfType<GameManager>().Retry();
            }

            gameObject.SetActive(false);
        }
    }

    private void InstantiatePlayerDestruction()
    {
        var transform1 = transform;
        Instantiate(playerDestruction, transform1.position, transform1.rotation);
    }
}