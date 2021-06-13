using UnityEngine;
using System;

namespace Assets.Scripts.GameManager
{
    public abstract class LevelManager : MonoBehaviour
    {
        public Action onLevelCompletion;


        protected abstract void OnLevelComplete();
    }
}