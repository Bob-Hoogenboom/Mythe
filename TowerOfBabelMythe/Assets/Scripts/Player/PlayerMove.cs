using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    [SerializeField] Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector3(moveHorizontal, _rb.velocity.y, 0) * _speed;

        
    }
}
