using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private Transform _player;
    private PlayerHorizontalMovement _playerHorizontalMovement;
    public Transform otherGround;
 
    [Range(-15, 0)] public int ySpawnPositionMinValue;
    [Range(1, 15)] public int ySpawnPositionMaxValue;
    
    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _playerHorizontalMovement = GameObject.Find("Player").GetComponent<PlayerHorizontalMovement>();
    }

    void FixedUpdate()
    {
        var thisTransform = transform;
        var thisPosition = thisTransform.position;
        var thisScale = thisTransform.localScale;

        // Calculations Start
        if (thisPosition.x + (thisScale.x / 2) + 10f < _player.position.x)
        {
            var playerVelocityX = _playerHorizontalMovement.velocity.x;
            
            var otherGroundPosition = otherGround.position;
            
            var randomScaleX = Random.Range(playerVelocityX / 2, playerVelocityX);
            var randomPositionX = Random.Range(playerVelocityX / 7, playerVelocityX / 2);
            var randomPositionY = Random.Range(ySpawnPositionMinValue, ySpawnPositionMaxValue);
            
            if (randomPositionY % 2 == 1)
            {
                randomPositionY += 1;
            }

            if (randomPositionY % 2 == -1)
            {
                randomPositionY -= 1;
            }

            if (playerVelocityX <= _playerHorizontalMovement.maxHorizontalVelocity * 0.9)
            {
                randomScaleX += 75;
            }
            
            thisScale.x = randomScaleX;
            thisPosition.x = otherGroundPosition.x + (otherGround.localScale.x / 2) + (thisScale.x / 2) + randomPositionX;
            thisPosition.y = otherGroundPosition.y + randomPositionY;
            
            // Height check, we don't want them to go down any higher or lower
            if (thisPosition.y > 8)
            {
                thisPosition.y = 8;
            }

            if (thisPosition.y < -22)
            {
                thisPosition.y = -22;
            }
            // End of height check
            transform.localScale = thisScale;
            transform.position = thisPosition;
        }
        // Calculations End
    }
}