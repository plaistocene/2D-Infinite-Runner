using UnityEngine;

public class PlayerReverseDash : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    public bool canReverseDash = true;
    public bool reverseDash;
    [Range(1, 10)] public float reverseDashForce = 3f;
    public float reverseDashCooldownTime = 4f;
    public float reverseDashTimer;
    
    public bool shouldSpeedRecover;
    public float speedRecoverCountdownTime = 0.5f;
    public float speedRecoverTimer;
    public float increasedSpeed;
    
    private VelocityChangeFunctions _velocityChangeFunctions;
    private AudioManager _audioManager;
    [SerializeField] private ParticleSystem jumpDust;
    public bool a_reverseDashScale;
    public bool a_reverseDashSpeedRecoverSpeed;
    

    private void Awake()
    {   
        _audioManager = FindObjectOfType<AudioManager>();
        _rb2d = GetComponent<Rigidbody2D>();
        _velocityChangeFunctions = GetComponent<VelocityChangeFunctions>();
        jumpDust = GameObject.Find("JumpDust").GetComponent<ParticleSystem>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canReverseDash)
        {
            reverseDash = true;
            canReverseDash = false;
            reverseDashTimer = reverseDashCooldownTime;
            a_reverseDashScale = true;
            jumpDust.Play();
            _audioManager.Play("ReverseDash");
        }

        if (!canReverseDash)
        {
            reverseDashTimer -= Time.deltaTime;

            if (reverseDashTimer <= 0f)
            {
                canReverseDash = true;
                reverseDashTimer = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        // ReverseDash
        if (reverseDash)
        {
            reverseDash = false;
            shouldSpeedRecover = true;

            increasedSpeed = (_rb2d.velocity.x / reverseDashForce);

            _velocityChangeFunctions.IncreaseHorizontalVelocity(increasedSpeed);
        }

        if (shouldSpeedRecover)
        {
            speedRecoverTimer += Time.fixedDeltaTime;
            
            if (speedRecoverTimer >= speedRecoverCountdownTime)
            {
                shouldSpeedRecover = false;
                speedRecoverTimer = 0f;

                a_reverseDashSpeedRecoverSpeed = true;

                _velocityChangeFunctions.DecreaseHorizontalVelocity(increasedSpeed);
            }
        }
    }
}
