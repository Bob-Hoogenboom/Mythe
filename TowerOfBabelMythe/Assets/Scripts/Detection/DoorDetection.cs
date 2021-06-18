using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Detection
{
    public class DoorDetection : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<PlayerManager>().atDoor = true;
        }
        private void OnTriggerExit(Collider other)
        {
            other.GetComponent<PlayerManager>().atDoor = false;
        }
    }
}