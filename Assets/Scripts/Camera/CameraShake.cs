using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Variables

    [SerializeField] [Range(0, 10)] private float shakeDuration;
    [SerializeField] [Range(0, 10)] private float shakePower;
    private Camera _camera;

    private PlayerJump _playerJump;

    [SerializeField] private float cameraRotationControlTimer;
    private bool _fixCameraRotation;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        _camera = Camera.main;
        _playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
    }

    private void Update()
    {
        if (cameraRotationControlTimer <= 2f)
        {
            cameraRotationControlTimer += Time.deltaTime;
        }
        else
        {
            cameraRotationControlTimer = 0f;
            _fixCameraRotation = true;
        }
    }

    private void FixedUpdate()
    {
        if (_playerJump.a_groundHit)
        {
            _playerJump.a_groundHit = false;
            _camera.DOShakeRotation(shakeDuration, shakePower);
        }

        if (_fixCameraRotation)
        {
            _fixCameraRotation = false;
            _camera.transform.eulerAngles = Vector3.zero;
        }
    }

    #endregion
}