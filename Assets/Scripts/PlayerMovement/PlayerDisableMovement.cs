using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisableMovement : MonoBehaviour
{
    public void DisableMovement()
    {
        FindObjectOfType<PlayerHorizontalMovement>().enabled = false;
        FindObjectOfType<PlayerJump>().enabled = false;
    }
}
