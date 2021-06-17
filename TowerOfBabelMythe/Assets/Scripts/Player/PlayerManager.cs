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
    private int _health;
    public int health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health >= 0)
            {
                Die();
            }
        }
    }

    private void Awake()
    {
        controlScript = GetComponent<PlayerController>();
    }

    private void Die()
    {
        //I fuckin' died;
        Debug.Log("Ded");
    }
}
