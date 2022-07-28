using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    #region Variables

    public Rigidbody2D[] playerPieces;
    [SerializeField] public bool isForceAdded;
    [SerializeField] public int minValue;
    [SerializeField] public int maxValue;

    #endregion

    #region Unity Methods

    private void FixedUpdate()
    {
        if (!isForceAdded)
        {
            isForceAdded = true;
            foreach (var p in playerPieces)
            {
                p.AddForce(
                    new Vector2(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue)) *
                    Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
        }
    }

    #endregion
}