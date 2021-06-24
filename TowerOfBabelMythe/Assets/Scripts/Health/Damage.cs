using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damagePoints = 1f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Damage Dealth");


        Health H = other.GetComponent<Health>();

        H.healthPoints -= damagePoints;

    }
}
