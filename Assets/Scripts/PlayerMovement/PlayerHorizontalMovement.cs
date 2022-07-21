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

    public bool canReverseDash = true;
    public bool reverseDash = false;
    [Range(1, 10)] public float reverseDashForce = 3f;
    public float reverseDashCooldownTime = 4f;
    public float reverseDashTimer = 0f;

    public bool shouldSpeedRecover = false;
    public float speedRecoverCountdownTime = 0.5f;
    public float speedRecoverTimer = 0f;
    public float loweredSpeed;


    public Vector2 velocityForGroundGeneration;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canReverseDash)
        {
            reverseDash = true;
            canReverseDash = false;
        }

        if (canReverseDash) return;
        reverseDashTimer += Time.deltaTime;

        if (!(reverseDashTimer >= reverseDashCooldownTime)) return;
        canReverseDash = true;
        reverseDashTimer = 0f;
    }

    // TODO: This parts needs a refactoring
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

        if (_rb2d.velocity.x < velocityFromPast && !shouldSpeedRecover)
        {
            _speedRecovered = false;
            VelocityChange(Vector2.right * velocityFromPast);
        }

        if (_rb2d.velocity.x >= velocityFromPast)
        {
            _speedRecovered = true;
        }


        // ReverseDash
        if (reverseDash)
        {
            reverseDash = false;
            shouldSpeedRecover = true;

            loweredSpeed = (_rb2d.velocity.x / reverseDashForce);

            VelocityChange(Vector2.left * loweredSpeed);
        }

        if (shouldSpeedRecover)
        {
            speedRecoverTimer += Time.fixedDeltaTime;
        }

        if (shouldSpeedRecover && speedRecoverTimer >= speedRecoverCountdownTime)
        {
            shouldSpeedRecover = false;
            speedRecoverTimer = 0f;

            VelocityChange(Vector2.right * loweredSpeed);
        }

        velocityForGroundGeneration = _rb2d.velocity;
        distance += velocityForGroundGeneration.x * Time.deltaTime;
    }

    private void VelocityChange(Vector2 otherVelocity)
    {
        _rb2d.velocity += otherVelocity;
    }
}