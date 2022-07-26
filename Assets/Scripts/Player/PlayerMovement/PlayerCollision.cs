using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.collider.CompareTag("Hostile")) return;
        FindObjectOfType<PlayerDisableMovement>().DisableMovement();

        FindObjectOfType<GameManager>().EndGame();
    }
}