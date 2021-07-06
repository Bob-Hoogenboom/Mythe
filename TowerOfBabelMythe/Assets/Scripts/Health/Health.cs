using UnityEngine;
using SoundLibrary;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;
    private Assets.Scripts.AudioHandler _audioHandler;

    void Start()
    {
        currentHealth = maxHealth;
        _audioHandler = GetComponentInChildren<Assets.Scripts.AudioHandler>();
    }

    public void TakeDamagePlayer(int enemyDamage) // public so the enemy can deal damage to the Player
    {
        currentHealth -= enemyDamage;
        _audioHandler.Play(Sounds.GetHurt);
        if(currentHealth <= 0)
        {
            Death();
        }
        Debug.Log("damaged Player");
    }

    void Death()
    {
        Destroy (gameObject);
    }

}
