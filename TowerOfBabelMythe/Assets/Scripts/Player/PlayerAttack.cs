using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Attack")] 
    [SerializeField] bool _attacking = false;

    [SerializeField] float _attackCd = .35f;
    [SerializeField] int _attackpower = 1;

    [SerializeField] Transform hitPoint;
    [SerializeField] float radius;

    [SerializeField] Animator _anime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_attacking) //Moue0 = left mouse button
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
            if (col.gameObject.tag == "Enemy") //Sword hits enemy, enemy takes damage
            {
                Debug.Log("damaged enemy");
                Enemy BEC = col.GetComponent<Enemy>();
                BEC.TakeDamage(_attackpower);
            }


        }
        yield return new WaitForSeconds(_attackCd);
        _attacking = false;
        //_anime.ResetTrigger("attacking");
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