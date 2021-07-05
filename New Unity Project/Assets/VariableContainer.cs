using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableContainer : MonoBehaviour
{
    private int _ourInt;
    public int ourInt
    {
        get
        {
            return _ourInt;
        }
        set
        {
            _ourInt = value;
        }
    }

    private string _secret;
    public string secret
    {
        get
        {
            return _secret;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ourInt = 5;
        Debug.Log(_ourInt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
