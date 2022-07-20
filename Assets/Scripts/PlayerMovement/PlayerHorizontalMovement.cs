using System;
using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public float distance = 0f;
    
    public float forwardForce = 2f;
    public float maxHorizontalVelocity = 100f;

    public bool canReverseDash = true;
    public bool reverseDash = false;
    [Range(1, 10)] public float reverseDashForce = 2f;
    public float reverseDashCooldownTime = 4f;
    public float reverseDashTimer = 0f;

    public bool shouldSpeedRecover = false;
    public float speedRecoverCountdownTime = 0.5f;
    public float speedRecoverTimer = 0f;
    public float loweredSpeed;
    
    
    public Vector2 testVelocity;

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

        if (!canReverseDash)
        {
            reverseDashTimer += Time.deltaTime;

            if (reverseDashTimer >= reverseDashCooldownTime)
            {
                canReverseDash = true;
                reverseDashTimer = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement
        if (_rb2d.velocity.x <= maxHorizontalVelocity)
        {
            _rb2d.AddForce(new Vector2(forwardForce, 0) * Time.fixedDeltaTime);
        }

        // This is just for me to check player velocity should be deleted
        testVelocity = _rb2d.velocity;

        // ReverseDash
        if (reverseDash)
        {
            reverseDash = false;
            shouldSpeedRecover = true;
            var velocity = _rb2d.velocity;
            
            loweredSpeed = velocity.x / reverseDashForce;

            velocity = new Vector2(velocity.x - loweredSpeed, 0);

            _rb2d.velocity = velocity;
        }

        if (shouldSpeedRecover)
        {
            speedRecoverTimer += Time.fixedDeltaTime;
        }

        if (shouldSpeedRecover && speedRecoverTimer >= speedRecoverCountdownTime)
        {
            shouldSpeedRecover = false;
            speedRecoverTimer = 0f;
            var velocity = _rb2d.velocity;
            
            velocity = new Vector2(loweredSpeed + velocity.x, velocity.y);
            
            _rb2d.velocity = velocity;
        }
        
        distance += testVelocity.x * Time.deltaTime;
    }
}