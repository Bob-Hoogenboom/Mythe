using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _Speed = 5f;
    [SerializeField] float _JumpHeight = 5f;
    [SerializeField] Rigidbody _Rb;
    [SerializeField] Vector2 _Movement;

    private void Start()
    {
        _Rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _Movement = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        CharMove(_Movement);
    }

    private void CharMove(Vector2 dir)
    {
        _Rb.MovePosition((Vector2)transform.position + (dir * _Speed * Time.deltaTime));
    }


}
