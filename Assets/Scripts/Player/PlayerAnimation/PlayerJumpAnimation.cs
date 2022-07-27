using DG.Tweening;
using UnityEngine;

public class PlayerJumpAnimation : MonoBehaviour
{
    #region Variables

    private PlayerJump _playerJump;

    [SerializeField] private float targetUpScale = 3f;

    [SerializeField] private Vector3 stretchScale;

    [SerializeField][Range(0, 1)] private float duration;

    [SerializeField] public bool reverseDashScale;
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        _playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
    }

    private void FixedUpdate()
    {
        if (_playerJump.a_scale)
        {
            _playerJump.a_scale = false;
            transform.DOScale(stretchScale, duration);
        }

        if (_playerJump.a_falling && !reverseDashScale)
        {
            _playerJump.a_falling = false;
            transform.DOScale(targetUpScale, duration).SetEase(Ease.OutBounce);
        }
    }

    #endregion
}