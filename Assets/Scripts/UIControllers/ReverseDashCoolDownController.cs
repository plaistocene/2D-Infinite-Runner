using UnityEngine;
using UnityEngine.UI;

public class ReverseDashCoolDownController : MonoBehaviour
{
    private PlayerReverseDash _playerReverseDash;
    private Text _coolDownTime;

    private void Awake()
    {
        _playerReverseDash = GameObject.Find("Player").GetComponent<PlayerReverseDash>();
        _coolDownTime = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        _coolDownTime.text = _playerReverseDash.reverseDashTimer.ToString("0.0");
    }
}
