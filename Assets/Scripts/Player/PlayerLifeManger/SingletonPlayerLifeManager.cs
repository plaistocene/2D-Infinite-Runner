using UnityEngine;

public class SingletonPlayerLifeManager : MonoBehaviour
{
    #region Variables

    private static SingletonPlayerLifeManager _instance;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    #endregion
}