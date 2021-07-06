using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamagePlayer(int enemyDamage) // public so the enemy can deal damage to the Player
    {
        currentHealth -= enemyDamage;
        Debug.Log("damaged Player");
    }

    void Death()
    {
        Destroy (gameObject);
    }

}
