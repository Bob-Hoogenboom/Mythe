using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            //right
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance._MoveRight = true;
            }
            else
            {
                VirtualInputManager.Instance._MoveRight = false;
            }

            //left
            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance._MoveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance._MoveLeft = false;
            }
        }
    }
}
