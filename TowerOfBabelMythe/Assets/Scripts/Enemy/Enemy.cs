using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] BasicEnemyController enemyController;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        enemyController.SwitchState(BasicEnemyController.EnemyState.Hurt);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
