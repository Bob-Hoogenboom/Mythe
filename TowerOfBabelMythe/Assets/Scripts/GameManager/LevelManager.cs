using UnityEngine;
using System;

namespace Assets.Scripts.GameManager
{
    public class LevelManager : MonoBehaviour
    {
        public Action onLevelCompletion;
        public int enemyCount;
        private bool _isDoorOpen = false;

        private void Awake()
        {
/*            enemyCount = CountingEnemies();*/
            Debug.Log(enemyCount);
        }

/*        public int CountingEnemies()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<TempScripts.EnemyTemp>().onDestroy += OnEnemyDestroy;
            }

            double i = 0;
            i = enemies.Length * 0.8;
            return (int)Math.Ceiling(i);
        }*/

        private void OnEnemyDestroy()
        {
            enemyCount--;
            if (enemyCount <= 0 && !_isDoorOpen)
            {
                _isDoorOpen = true;
                OpenDoor();
            }
        }

        private void OpenDoor()
        {

        }
    }
}