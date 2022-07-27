using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _player;
    
    public Vector3 offset;
    // public float smoothingFactor = 0.125f;
    [SerializeField] [Range(0, 1)] private float duration;
    [SerializeField] private bool snapping;
    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = _player.position + offset;
        
        // var desiredPosition = _player.position + offset;
        // var smoothPosition = Vector3.Lerp(transform.position, desiredPosition, 0f);
        // transform.position = smoothPosition;
        
        // var desiredPosition = _player.position + offset;
        // transform.DOMoveX(desiredPosition.x, 0f, false);
        // transform.DOMoveY(desiredPosition.y, 0f, false);
    }
}
