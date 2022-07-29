using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public float distance;

    public float forwardForce = 500f;
    public float maxHorizontalVelocity;
    public bool maxSpeedReached;

    // This velocity will be used for if player can recover from hitting the side of the building but manage to jump in time
    public float velocityFromPast;
    public float timeForPast = 2f;
    public float pastTimeCounter;
    private bool _speedRecovered = true;

    private VelocityChangeFunctions _velocityChangeFunctions;
    private PlayerReverseDash _playerReverseDash;

    public Vector2 velocity;

    private void Awake()
    {
        _velocityChangeFunctions = GetComponent<VelocityChangeFunctions>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerReverseDash = GetComponent<PlayerReverseDash>();
    }

    void FixedUpdate()
    {
        // Horizontal movement
        if (velocity.x <= 50)
        {
            _rb2d.velocity = new Vector2(50, _rb2d.velocity.y);
        }

        velocity = _rb2d.velocity;
        distance += velocity.x * Time.deltaTime;
    }
}