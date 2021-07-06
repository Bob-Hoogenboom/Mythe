using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerController controlScript;
    private bool _inControl = false;
    public bool inControl
    {
        get
        {
            return _inControl;
        }
        set
        {
            _inControl = value;
            controlScript.enabled = value;
        }
    }
    public bool atDoor = false;

    private void Awake()
    {
        controlScript = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)&& atDoor)
        {
            FindObjectOfType<Assets.Scripts.GameManager.LevelManager>().onLevelCompletion();
            atDoor = false;
        }
    }
}
