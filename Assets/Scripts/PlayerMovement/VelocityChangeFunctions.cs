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

    public void IncreaseVelocity(float value)
    {
        VelocityChange(Vector2.right * value);
    }

    public void DecreaseVelocity(float value)
    {
        VelocityChange(Vector2.left * value);
    }
    
    private void VelocityChange(Vector2 otherVelocity)
    {
        _rb2d.velocity += otherVelocity;
    }
}
