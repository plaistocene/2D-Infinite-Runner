using DG.Tweening;
using UnityEngine;

public class PlayerReverseDashAnimation : MonoBehaviour
{
    #region Variables

    private PlayerReverseDash _playerReverseDash;

    [SerializeField] private Vector3 targetScale = new Vector3(3.5f, 1.5f, 1f);
    [SerializeField] private Vector3 originalScale = Vector3.one * 3;

    [SerializeField][Range(0, 1)] private float duration;
    private PlayerJumpAnimation _playerJumpAnimation;



    #endregion

    #region Unity Methods

    private void Awake()
    {
        _playerReverseDash = GameObject.Find("Player").GetComponent<PlayerReverseDash>();
        _playerJumpAnimation = GameObject.Find("Player").GetComponent<PlayerJumpAnimation>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_playerReverseDash.a_reverseDashScale)
        {
            _playerReverseDash.a_reverseDashScale = false;
            _playerJumpAnimation.reverseDashScale = true;
            
            transform.DOScale(targetScale, duration);
        }

        if (_playerReverseDash.a_reverseDashSpeedRecoverSpeed)
        {
            _playerReverseDash.a_reverseDashSpeedRecoverSpeed = false;
            _playerJumpAnimation.reverseDashScale = false;

            transform.DOScale(originalScale, duration);
        }
    }
    
    #endregion
}
