using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaryMovement : MonoBehaviour
{
    [SerializeField] GameObject _pivotPoint;
    [SerializeField] float _speed = 5f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.RotateAround(_pivotPoint.transform.position, Vector3.up, _speed * Time.deltaTime);
    }
}
