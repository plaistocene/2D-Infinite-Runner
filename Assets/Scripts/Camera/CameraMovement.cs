using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _player;
    
    public Vector3 offset;
    public float smoothingFactor = 0.125f;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        var desiredPosition = _player.position + offset;
        var smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothingFactor);
        transform.position = smoothPosition;
    }
}
