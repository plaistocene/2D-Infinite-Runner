using UnityEngine;
using UnityEngine.UI;

public class SetGameOverScore : MonoBehaviour
{
    #region Variables

    [SerializeField] private Text endScoreText;
    
    #endregion

    #region Unity Methods
    
    private void Awake()
    {
        endScoreText = GameObject.Find("GameOverScore").GetComponent<Text>();
    }

    public void SetText(string distance)
    {
        endScoreText.text = distance;
    }
    
    #endregion
    
}
