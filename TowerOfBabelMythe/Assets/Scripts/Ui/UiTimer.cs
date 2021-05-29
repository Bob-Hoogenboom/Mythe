using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.Ui
{
    public class UiTimer : MonoBehaviour
    {
        private GameManager.Timer _timer;
        [SerializeField] private Text _displayTime;

        void Awake()
        {
            _timer = FindObjectOfType<GameManager.Timer>();
        }

        // Update is called once per frame
        void Update()
        {
            _displayTime.text = TimeFormatter(_timer.GetTimer());
        }

        private string TimeFormatter(float f)
        {
            int intTime = (int)f;
            int minutes = intTime / 60;
            int seconds = intTime % 60;
            return string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
    }
}