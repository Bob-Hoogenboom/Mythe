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

    public void Death()
    {
        Destroy (gameObject);
        Assets.Scripts.GameManager.GameManager gm = FindObjectOfType<Assets.Scripts.GameManager.GameManager>();
        gm.StartCoroutine("LoadLevel", gm.levelDatas[0]);
    }

}
