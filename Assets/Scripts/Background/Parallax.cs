using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Range(1, 15)] public int depth = 1;

    private Transform _mainCamera;
    private Rigidbody2D _playerRigidbody2d;

    private void Awake()
    {
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
        _playerRigidbody2d = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var realVelocity = _playerRigidbody2d.velocity.x / depth;

        Vector2 pos = transform.position;

        // Calculations Start
        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x < _mainCamera.position.x - 30f)
            pos.x = _mainCamera.position.x + 30f;
        // Calculations End

        transform.position = pos;
    }
}