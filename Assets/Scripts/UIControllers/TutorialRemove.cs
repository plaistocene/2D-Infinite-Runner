using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRemove : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject tutorial;
    private bool _isTutorialHidden;

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTransform.position.x >= 150 && !_isTutorialHidden)
        {
            _isTutorialHidden = true;
            tutorial.SetActive(false);
        }
    }
}
