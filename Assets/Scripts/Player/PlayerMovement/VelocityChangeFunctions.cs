using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityChangeFunctions : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void IncreaseVerticalVelocity(float value)
    {
        VelocityChange(Vector2.up * value);
    }

    public void DecreaseVerticalVelocity(float value)
    {
        VelocityChange(Vector2.down * value);
    }

    public void IncreaseHorizontalVelocity(float value)
    {
        VelocityChange(Vector2.right * value);
    }

    public void DecreaseHorizontalVelocity(float value)
    {
        VelocityChange(Vector2.left * value);
    }
    
    private void VelocityChange(Vector2 otherVelocity)
    {
        _rb2d.velocity += otherVelocity;
    }
}
