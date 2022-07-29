using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Variables

    private GameObject _player;
    public Vector2 offset;
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        var followPosition = _player.transform.position;

        followPosition.x += offset.x;
        followPosition.y += offset.y;

        transform.position = followPosition;
    }
    
    #endregion

    public void SetOffset(Vector2 offsetValue)
    {
        offset = offsetValue;
    }
}
