using UnityEngine;

public class DestroyPlayerLife : MonoBehaviour
{
    #region Variables
    
    public GameObject playerDestruction;
    
    #endregion

    public void DestroyLife()
    {
        var transform1 = transform;
        Instantiate(playerDestruction, transform1.position, transform1.rotation);
        Destroy(gameObject);
    }
}
