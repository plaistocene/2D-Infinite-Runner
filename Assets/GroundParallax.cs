using UnityEngine;

public class GroundParallax : MonoBehaviour
{
    [Range(1, 15)] public int depth = 1;

    private Transform _player;
    public Transform otherGround;
    public float distanceLowerRange = 20f;
    public float distanceUpperRange = 35f;

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
            pos.x = position.x + otherGround.localScale.x + Random.Range(distanceLowerRange, distanceUpperRange);
            pos.y = position.y;
        }
        // Calculations End

        transform.position = pos;
    }
}