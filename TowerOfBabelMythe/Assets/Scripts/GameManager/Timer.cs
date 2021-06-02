using UnityEngine;
using System.Collections;

namespace Assets.Scripts.GameManager
{
    public class Timer : MonoBehaviour
    {
        private bool _isTimerRunning = false;
        private bool _isTimeSet = false;
        private bool _isTimerDone = false;
        public float currentTime;

        private void Start()
        {
            _isTimerRunning = true;
        }

        void Update()
        {
            TimerTick(_isTimerRunning);
        }

        private void TimerTick(bool b)
        {
            if(b)
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0 && !_isTimerDone)
                {
                    Debug.Log("Tower go bye bye");
                    _isTimerRunning = false;
                    _isTimerDone = true;
                }
            }
        }

        public float GetTimer()
        {
            return currentTime;
        }

        public void SetTimer(float f)
        {
            if(!_isTimeSet)
            {
                currentTime = f;
                _isTimeSet = true;
                Debug.Log("Timer is set to " + currentTime);
            } else
            {
                Debug.LogError("The timer can only be set once");
            }
        }

        public void PauseTimer()
        {
            _isTimerRunning = false;
        }

        public void StartTimer()
        {
            _isTimerRunning = true;
        }
    }
}