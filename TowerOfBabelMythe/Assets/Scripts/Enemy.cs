using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
           
    void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
