using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private AudioManager _audioManager;
    public GameObject playerDestruction;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Hostile"))
        {
            FindObjectOfType<PlayerDisableMovement>().DisableMovement();
            
            var transform1 = transform;
            Instantiate(playerDestruction, transform1.position, transform1.rotation);
            
            _audioManager.Play("Death");
            
            FindObjectOfType<GameManager>().EndGame();
            gameObject.SetActive(false);
        }
    }
}