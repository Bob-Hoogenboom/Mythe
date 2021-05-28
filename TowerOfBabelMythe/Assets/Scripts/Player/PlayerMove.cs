using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] bool _faceRight = true;
    [SerializeField] float _moveSpeed = 25f;
    [SerializeField] Vector2 _dir;

    [Header("Verticle Movement")]
    [SerializeField] float _jumpForce = 15f;
    [SerializeField] float _jumpDelay = 0.25f;
    [SerializeField] float _jumpTimer;

    [Header("Components")]
    [SerializeField] Animator _anime;
    [SerializeField] Rigidbody _rb;
    [SerializeField] LayerMask _groundLayer;

    [Header("Physics")]
    [SerializeField] float _maxFast = 70f;
    [SerializeField] float _linearDrag = 4f;
    [SerializeField] float _gravity = 1;
    [SerializeField] float _fallMultiplier = 5f;

    [Header("Collision")]
    [SerializeField] bool _isGrounded = false;
    [SerializeField] float _rayLength = 0.5f;
    [SerializeField] Vector3 _colOffset;


    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position + _colOffset, Vector2.down, _rayLength, _groundLayer) ||
                        Physics.Raycast(transform.position - _colOffset, Vector2.down, _rayLength, _groundLayer);

        if(Input.GetButtonDown("Jump"))
        {
            _jumpTimer = Time.time + _jumpDelay;
        }

        _dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }


    private void FixedUpdate()
    {
        MoveCharacter(_dir.x);
        if(_jumpTimer > Time.time && _isGrounded)
        {
            Jump();
        }
        PhysicsMod();
    }


    void MoveCharacter(float horizontal)
    {
        _rb.AddForce(Vector2.right * horizontal * _moveSpeed);

        _anime.SetFloat("horizontal", Mathf.Abs(_rb.velocity.x)); //'Mathf.Abs' makes sure the value is always positive

        if((horizontal > 0 && !_faceRight) || (horizontal< 0 && _faceRight))
        {
            FlipDirection();
        }
        if(Mathf.Abs(_rb.velocity.x) > _maxFast)
        {
            _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x)* _maxFast, _rb.velocity.y); //'Mathf.Sign' when f is positive or zero it returns 1 and if f is negative it returns -1
        }
    }


    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        _jumpTimer = 0;
    }


    void PhysicsMod()
    {
        bool changeDir = (_dir.x > 0 && _rb.velocity.x < 0) || (_dir.x < 0 && _rb.velocity.x > 0);

        if (_isGrounded)
        {
            if (Mathf.Abs(_dir.x) < 0.4f || changeDir)
            {
                _rb.drag = _linearDrag;
            }
            else
            {
                _rb.drag = 0;
            }
        _rb.useGravity = false;
        }
        else
        {
            _rb.useGravity = true;
            _rb.drag = _linearDrag * 0.15f;
            if(_rb.velocity.y < 0)
            {
                Vector3 gravity = _gravity * _fallMultiplier * Vector3.down;
                _rb.AddForce(gravity, ForceMode.Acceleration);
            }
            else if(_rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                Vector3 gravity = _gravity * _fallMultiplier * Vector3.up;
            }
        }
    }



    void FlipDirection()
    {
        _faceRight = !_faceRight;
        transform.rotation = Quaternion.Euler(0, _faceRight ? 0 : 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + _colOffset, transform.position + _colOffset + Vector3.down * _rayLength);
        Gizmos.DrawLine(transform.position - _colOffset, transform.position - _colOffset + Vector3.down * _rayLength);
    }


}


