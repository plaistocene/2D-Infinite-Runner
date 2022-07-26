using UnityEngine;

public class PlayerDisableMovement : MonoBehaviour
{
    public void DisableMovement()
    {
        FindObjectOfType<PlayerHorizontalMovement>().enabled = false;
        FindObjectOfType<PlayerJump>().enabled = false;
    }
}
