using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(other.name);
            other.GetComponent<PlayerManager>().Die();
        }
    }
}
