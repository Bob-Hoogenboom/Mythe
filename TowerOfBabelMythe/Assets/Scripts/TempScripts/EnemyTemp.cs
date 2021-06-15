using UnityEngine;
using System;
using System.Collections;

namespace Assets.Scripts.TempScripts
{
    public class EnemyTemp : MonoBehaviour
    {
        public Action onDestroy;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(onDestroy != null)
                {
                    onDestroy();
                }
                Destroy(this);
            }
        }
    }
}