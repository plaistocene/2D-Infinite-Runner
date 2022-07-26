using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public float jumpForce;
    public bool onGround;
    public bool jump;
    public bool closeEnoughGround;

    public float fallMultiplier;
    public float lowJumpMultiplier;
    
    private VelocityChangeFunctions _velocityChangeFunctions;

    public bool a_groundHit;
    public bool a_scale;
    public bool a_falling;
    
    private void Awake()
    {
        _velocityChangeFunctions = GetComponent<VelocityChangeFunctions>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && (onGround || closeEnoughGround))
        {
            jump = true;
            a_scale = true;
            onGround = false;
            closeEnoughGround = false;
        }
    }

    // using 'Fixed' Update because we are messing with the physics
    void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            _velocityChangeFunctions.IncreaseVerticalVelocity(jumpForce * Time.deltaTime);
        }

        if (_rb2d.velocity.y < 0)
        {
            _velocityChangeFunctions.DecreaseVerticalVelocity(Physics.gravity.y * -fallMultiplier * Time.deltaTime);
            a_falling = true;
        }

        if (_rb2d.velocity.y > 0 && !IsJumping())
        {
            _velocityChangeFunctions.DecreaseVerticalVelocity(Physics.gravity.y * -lowJumpMultiplier * Time.deltaTime);
            a_falling = true;
        }
    }

    private static bool IsJumping()
    {
        return Input.GetKey("space") || Input.GetKey("w");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            a_groundHit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            closeEnoughGround = true;
        }
    }
}