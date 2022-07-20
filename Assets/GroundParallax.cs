using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParallax : MonoBehaviour
{
    [Range(1, 15)] public int depth = 1;

    private Transform _player;
    public Transform otherGround;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        // Calculations Start
        if (pos.x + (transform.localScale.x / 2) + 10f < _player.position.x)
        {
            var position = otherGround.position;
            pos.x = position.x + otherGround.localScale.x - 10f;
            pos.y = position.y;
        }
        // Calculations End

        transform.position = pos;
    }
}