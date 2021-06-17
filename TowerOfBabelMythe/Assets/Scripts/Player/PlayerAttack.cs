using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Attack")] 
    [SerializeField] bool _attacking = false;

    [SerializeField] float _attackTimer = 0;
    [SerializeField] float _attackCd = .35f;
    

    [SerializeField] Transform hitPoint;
    [SerializeField] float radius;

    [SerializeField] Animator _anime;

    private bool _attackTrigger = false;

    void Awake()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2) && !_attacking) //Moue2 = left mouse button
        {
            StartCoroutine("Attack");
        }
    }


    IEnumerator Attack()
    {
        _anime.SetTrigger("attacking");
        Collider[] cols = Physics.OverlapSphere(hitPoint.position, radius);
        foreach (Collider col in cols)
        {

            _attacking = true;
            Debug.Log(col.gameObject.name);
            if (col.gameObject.tag == "Enemy")
            {
                Debug.Log(col.gameObject.name);
            }
        }
        yield return new WaitForSeconds(_attackCd);
        _attacking = false;
        _anime.ResetTrigger("attacking");
        yield return null; 
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }
}



/*_attacking = true;
_attackTimer = _attackCd;
while (_attacking)
{
    Collider[] cols = Physics.OverlapSphere(hitPoint.position, radius);
    foreach (Collider col in cols)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "Enemy")
        {
            *//*Debug.Log(col.gameObject.name);*//*
        }
    }
}*/