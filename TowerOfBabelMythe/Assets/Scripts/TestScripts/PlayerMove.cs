using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _feetPos;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius;
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private bool isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CharacterMovement(InputParse());
    }

    private void Update()
    {
        Debug.Log(GroundCheck());
    }

    private void CharacterMovement(float dir)
    {
        _rb.velocity = new Vector2(dir * _speed, _rb.velocity.y);
    }

    private float InputParse()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    private bool GroundCheck()
    {
        Collider[] col = Physics.OverlapSphere(_feetPos.position, _checkRadius, _groundLayer);
        foreach(Collider overLap in col)
        {
            Debug.Log(overLap.name);
            Debug.Log(overLap.gameObject.layer);
            if(overLap.gameObject.layer == 8)
            {
                Debug.Log("HEY IT'S TRUE");
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}