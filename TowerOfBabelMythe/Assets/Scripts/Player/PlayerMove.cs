using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] Vector2 _dir;


    [Header("Components")]
    [SerializeField] Rigidbody _rb;

    private void Update()
    {
        _dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        MoveCharacter(_dir.x);
    }

    void MoveCharacter(float horizontal)
    {
        _rb.AddForce(Vector2.right * horizontal * _moveSpeed);
    }


}


