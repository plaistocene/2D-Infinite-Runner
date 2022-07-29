using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private int playerLives = 3;

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
        
        instantiatedPlayerLives.Add(Instantiate(playerLife, position, rotation));
        instantiatedPlayerLives.Add(Instantiate(playerLife, position, rotation));
        instantiatedPlayerLives.Add(Instantiate(playerLife, position, rotation));
        
        foreach (var live in instantiatedPlayerLives)
        {
            live.GetComponent<FollowPlayer>().SetOffset(offset);
            offset.x += 1.5f;
        }
    }
    
    #region Player Life Modifications

    public int ReducePlayerLivesByOne()
    {
        playerLives -= 1;
        return playerLives;
    }

    public void IncreasePlayerLivesByOne()
    {
        playerLives += 1;
    }

    public void ResetPlayerHealth()
    {
        playerLives = 3;
    }

    #endregion
    
    #region Getters

    public int GetPlayerLives()
    {
        return playerLives;
    }

    #endregion
}