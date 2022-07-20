using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private Transform _player;
    private PlayerHorizontalMovement _playerHorizontalMovement;
    public Transform otherGround;
 
    public float distanceLowerRange = 5f;
    public float distanceUpperRange;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _playerHorizontalMovement = GameObject.Find("Player").GetComponent<PlayerHorizontalMovement>();
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        // Calculations Start
        if (pos.x + (transform.localScale.x / 2) + 10f < _player.position.x)
        {
            distanceUpperRange = _playerHorizontalMovement.velocityForGroundGeneration.x / 2;
            
            var position = otherGround.position;
            pos.x = position.x + otherGround.localScale.x + Random.Range(distanceLowerRange, distanceUpperRange);
            pos.y = position.y + Random.Range(-11, 11);
            
            // Height check, we don't want them to go down any higher or lower
            if (pos.y > 8)
            {
                pos.y = 8;
            }

            if (pos.y < -22)
            {
                pos.y = -22;
            }
            // End of height check
        }
        // Calculations End

        transform.position = pos;
    }
}