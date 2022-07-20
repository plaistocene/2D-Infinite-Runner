using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public float jumpForce;
    public bool onGround;
    public bool jump = false;
    public bool closeEnoughGround = false;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && (onGround || closeEnoughGround))
        {
            jump = true;
        }
    }

    // using 'Fixed'Update because we are messing with the physics
    void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            _rb2d.velocity += Vector2.up * (jumpForce * Time.deltaTime);
            onGround = false;
            closeEnoughGround = false;
        }

        if (_rb2d.velocity.y < 0)
        {
            _rb2d.velocity += Vector2.up * (Physics.gravity.y * fallMultiplier * Time.deltaTime);
        }

        if (_rb2d.velocity.y > 0 && !IsJumping())
        {
            _rb2d.velocity += Vector2.up * (Physics.gravity.y * lowJumpMultiplier * Time.deltaTime);
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