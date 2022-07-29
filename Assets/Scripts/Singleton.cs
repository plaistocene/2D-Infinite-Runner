using UnityEngine;

public class Singleton : MonoBehaviour
{
    #region Variables

    private static Singleton _instance;

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