using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _tower;
    public Rigidbody rb;
    private float _distance;

    private void Awake()
    {
        _tower = GameObject.FindGameObjectWithTag("Tower").transform;
        _distance = Vector3.Distance(this.transform.position, _tower.position);
    }

    private void FixedUpdate()
    {
        //rb.centerOfMass = new Vector3(_tower.position.x, this.transform.position.y, _tower.position.z);
        CharacterMovement(InputParse());
    }

    private void LateUpdate()
    {
        
    }

    private void Update()
    {
        
    }

    private void CharacterMovement(float dir)
    {
        this.transform.RotateAround(_tower.position, Vector3.up, dir * _speed * Time.deltaTime * -1);
    }

    private float InputParse()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}