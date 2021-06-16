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
        AsyncOperation asyncLoadLevel;

        public IEnumerator LoadScene(Levels targetLevel)
        {
            asyncLoadLevel = SceneManager.LoadSceneAsync(targetLevel.ToString(), LoadSceneMode.Single);
            while(!asyncLoadLevel.isDone)
            {
                print("Loading the Scene");
                yield return null;
            }
            onLoad?.Invoke(targetLevel);
        }
    }
}