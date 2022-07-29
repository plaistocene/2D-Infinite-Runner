using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public float distance;

    public float maxHorizontalVelocity;
    
    public Vector2 velocity;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        // Horizontal movement
        if (_rb2d.velocity.x <= 50)
        {
            _rb2d.velocity = new Vector2(50, _rb2d.velocity.y);
        }

        velocity = _rb2d.velocity;
        distance += velocity.x * Time.deltaTime;
    }
}