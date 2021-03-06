using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _tower;
    private float _distance;

    private void Awake()
    {
        print("Uitgevoerd");
        _tower = GameObject.FindGameObjectWithTag("Tower").transform;
        _distance = Vector3.Distance(this.transform.position, _tower.position);
    }

    private void FixedUpdate()
    {
        CharacterMovement(InputParse());
    }

    public void CharacterMovement(float dir)
    {
        this.transform.RotateAround(_tower.position, Vector3.up, dir * _speed * Time.deltaTime * -1);
    }

    private float InputParse()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}