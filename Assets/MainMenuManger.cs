using System;
using UnityEngine;

public class MainMenuManger : MonoBehaviour
{
    #region Variables

    public GameObject mainMenu;
    public GameObject tutorial;
    
    private static bool _isMainMenuDisplayed;
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (!_isMainMenuDisplayed)
        {
            _isMainMenuDisplayed = true;
            mainMenu.SetActive(true);
            tutorial.SetActive(true);
        }
    }

    #endregion
}
