using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;
    public Slider slider;


    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        slider.value = currentHealth;
    }

    public void TakeDamagePlayer(int enemyDamage) // public so the enemy can deal damage to the Player
    {
        currentHealth -= enemyDamage;
        Debug.Log("damaged Player");

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Assets.Scripts.GameManager.GameManager gm = FindObjectOfType<Assets.Scripts.GameManager.GameManager>();
        gm.StartCoroutine("LoadLevel", gm.levelDatas[0]);
    }

}
