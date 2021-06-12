using UnityEngine;
using System.Collections;

namespace Assets.Scripts.TempScripts
{
    public abstract class TempMoveBase : MonoBehaviour
    {
        public abstract void Move(float  input);
        public abstract void Jump();
        public abstract void UpdateCall();

        public virtual void OptionalMove()
        {
            Debug.Log("This has not been altered");
        }
    }
}