using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using GameSystems;

namespace Assets.Scripts.GameManager
{
    public class LevelLoader : MonoBehaviour
    {
        [Range(0.0f, 0.01f)]
        [SerializeField]
        public Action<Levels> onLoad;

        public IEnumerator LoadScene(Levels targetLevel)
        {
            SceneManager.LoadScene(targetLevel.ToString());
            onLoad?.Invoke(targetLevel);
            yield return null;
        }
    }
}