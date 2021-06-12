using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool _inControl;
    public bool inControl
    {
        get
        {
            return _inControl;
        }
        set
        {
            _inControl = value;
        }
    }

    //Implement logic that inControl will make it so the player is controllable or not.
}
