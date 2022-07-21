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

        var transform1 = transform;
        
        Vector2 pos = transform1.position;
        Vector2 scale = transform1.localScale;

        // Calculations Start
        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x + (scale.x / 2) < _mainCamera.position.x - 35f)
            pos.x = _mainCamera.position.x + 35f + (scale.x / 2);
        // Calculations End

        transform.position = pos;
    }
}