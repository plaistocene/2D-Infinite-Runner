using System;
using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public float distance = 0f;

    public float forwardForce = 500f;

    public float maxHorizontalVelocity = 150f;

    // This velocity will be used if player can recover from hitting the side of the building but manage to jump in time
    public float velocityFromPast = 0f;
    public float timeForPast = 2f;
    public float pastTimeCounter = 0f;
    private bool _speedRecovered = true;
    
    
    public Vector2 velocityForGroundGeneration;
    private VelocityChangeFunctions _velocityChangeFunctions;
    private PlayerReverseDash _playerReverseDash;

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
        if (_rb2d.velocity.x <= maxHorizontalVelocity)
        {
            _rb2d.AddForce(Vector2.right * (forwardForce * Time.fixedDeltaTime));
        }

        // If character hits a high wall but recovers with jump
        pastTimeCounter += Time.fixedDeltaTime;

        if (timeForPast <= pastTimeCounter && _speedRecovered)
        {
            pastTimeCounter = 0f;
            velocityFromPast = _rb2d.velocity.x;
        }

        if (_rb2d.velocity.x < velocityFromPast && !_playerReverseDash.shouldSpeedRecover)
        {
            _speedRecovered = false;
            _velocityChangeFunctions.IncreaseVelocity(velocityFromPast);
            
            if (_rb2d.velocity.x >= velocityFromPast)
            {
                _speedRecovered = true;
            }
        }

        // TODO: remove velocity for ground generation, please, groundloop can also reach rigidbody
        velocityForGroundGeneration = _rb2d.velocity;
        distance += velocityForGroundGeneration.x * Time.deltaTime;
    }
    
}