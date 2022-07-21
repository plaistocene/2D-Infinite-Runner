using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private PlayerHorizontalMovement _playerHorizontalMovement;
    private Text _score;

    private void Awake()
    {
        _playerHorizontalMovement = GameObject.Find("Player").GetComponent<PlayerHorizontalMovement>();
        _score = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        _score.text = _playerHorizontalMovement.distance.ToString("0");
    }
}
