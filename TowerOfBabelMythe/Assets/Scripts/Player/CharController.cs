using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class CharController : MonoBehaviour
    {
        [SerializeField] float _Speed = 10;

        void Update()
        {
            if (VirtualInputManager.Instance._MoveRight && VirtualInputManager.Instance._MoveLeft)
            {
                return;
            }


                if (VirtualInputManager.Instance._MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.right * _Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (VirtualInputManager.Instance._MoveLeft)
            {
                this.gameObject.transform.Translate(Vector3.right * _Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }
}
