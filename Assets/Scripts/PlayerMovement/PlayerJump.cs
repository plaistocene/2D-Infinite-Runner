using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    
    public float gravity = -300f;
    public float jumpVelocity = 50f;
    public float groundHeight = -8f;
    public float maxJumpTime = 0.3f;
    public float jumpTimer = 0.0f;
    
    public bool onGround;
    public bool closeEnoughGround = false;
    public bool isHoldingJump = false;
    
    public Vector2 velocity;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && (onGround || closeEnoughGround))
        {
            onGround = false;
            closeEnoughGround = false;
            velocity.y = jumpVelocity;
            isHoldingJump = true;
            jumpTimer = 0f;
        }
        
        if(Input.GetKeyUp("space") || Input.GetKeyUp("w"))
        {
            isHoldingJump = false; 
        }
    }

    private void FixedUpdate()
    {
        // Getting the player position
        Vector2 pos = transform.position;

        // Teh calculations
        if (!onGround)
        {
            if (isHoldingJump)
            {
                jumpTimer += Time.fixedDeltaTime;
                
                if (jumpTimer >= maxJumpTime)
                {
                    isHoldingJump = false;
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime;

            if (!isHoldingJump)
            {
                if(!closeEnoughGround)
                {
                    velocity.y += gravity * Time.fixedDeltaTime;
                }
            }
        }

        
        transform.position = pos;
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
