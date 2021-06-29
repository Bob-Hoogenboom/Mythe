using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] BasicEnemyController enemyController;
    [SerializeField] private int _enemyDamage;

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage) //has to be public so the player can give damage to the enemy
    {
        health -= damage;
        enemyController.SwitchState(BasicEnemyController.EnemyState.Hurt);
    }

    public void DealDamage(int enemyDamage)
    {
        Health PC = GetComponent<Health>();
        PC.TakeDamagePlayer(_enemyDamage);
        Debug.Log("damaged Player");
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
