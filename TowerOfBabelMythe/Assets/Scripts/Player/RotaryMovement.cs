using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaryMovement : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] float _angle = 20f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.RotateAround(_target.transform.position, Vector3.up, _angle * Time.deltaTime);
    }
}
