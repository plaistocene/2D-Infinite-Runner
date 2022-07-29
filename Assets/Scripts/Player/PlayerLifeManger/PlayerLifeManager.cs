using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    #region Variables

    private static int _playerLives = 3;

    public GameObject playerLife;
    private GameObject _player;
    [SerializeField] private List<GameObject> instantiatedPlayerLives;

    public Vector2 offset;
    
    #endregion

    private void Awake()
    {
        _player = GameObject.Find("Player");

        InstantiatePlayerLivesIndicator();
    }

    private void InstantiatePlayerLivesIndicator()
    {
        var transform1 = _player.transform;
        var rotation = transform1.rotation;
        var position = transform1.position;

        for (int i = 0; i < _playerLives; i++)
        {
            instantiatedPlayerLives.Add(Instantiate(playerLife, position, rotation));
        }

        foreach (var live in instantiatedPlayerLives)
        {
            SetOffsetForFollowPlayer(live);
        }
    }

    private void SetOffsetForFollowPlayer(GameObject live)
    {
        live.GetComponent<FollowPlayer>().SetOffset(offset);
        offset.x += 1.5f;
    }

    #region Player Life Modifications

    public int ReducePlayerLivesByOne()
    {
        _playerLives -= 1;
        instantiatedPlayerLives.Last().GetComponent<DestroyPlayerLife>().DestroyLife();
        instantiatedPlayerLives.RemoveAt(instantiatedPlayerLives.Count - 1);
        offset.x -= 1.5f;
        return _playerLives;
    }

    public void IncreasePlayerLivesByOne()
    {
        _playerLives += 1;
        var transform1 = _player.transform;
        var rotation = transform1.rotation;
        var position = transform1.position;
        instantiatedPlayerLives.Add(Instantiate(playerLife, position, rotation));
        SetOffsetForFollowPlayer(instantiatedPlayerLives.Last());
    }

    public void ResetPlayerHealth()
    {
        _playerLives = 3;
    }

    #endregion

    #region Getters

    public int GetPlayerLives()
    {
        return _playerLives;
    }

    #endregion
}