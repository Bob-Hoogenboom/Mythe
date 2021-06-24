using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //sword Damage

    public int damagePoints = 1;

    void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "Enemy")
        {
            Enemy BEC = GetComponent<Enemy>();
            BEC.TakeDamage(damagePoints);
            Debug.Log("damaged enemy");
        }
    }
}



            /*    private void OnTriggerEnter(Collider other)
                {
                    Debug.Log("Damage Dealth");

                    H.healthPoints -= damagePoints;

                    Health H = other.GetComponent<Health>();
                }*/
