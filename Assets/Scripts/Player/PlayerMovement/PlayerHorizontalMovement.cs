using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public float distance;

    public float forwardForce = 500f;
    public float maxHorizontalVelocity;

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
        velocity = _rb2d.velocity;
        // Horizontal movement
        if (velocity.x <= maxHorizontalVelocity)
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

        if (velocity.x < velocityFromPast && !_playerReverseDash.shouldSpeedRecover)
        {
            _speedRecovered = false;
            _velocityChangeFunctions.IncreaseHorizontalVelocity(velocityFromPast);
            
            if (velocity.x >= velocityFromPast)
            {
                _speedRecovered = true;
            }
        }
        
        velocity = _rb2d.velocity;
        distance += velocity.x * Time.deltaTime;
    }
    
}