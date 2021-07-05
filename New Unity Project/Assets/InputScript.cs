using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("A-Button");
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            _animator.SetTrigger("B-Button");
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetTrigger("X-Button");
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            _animator.SetTrigger("Y-Button");
        }
    }
}
