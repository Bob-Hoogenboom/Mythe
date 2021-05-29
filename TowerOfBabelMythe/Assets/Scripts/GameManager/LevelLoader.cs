using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using GameSystems;

namespace Assets.Scripts.GameManager
{
    public class LevelLoader : MonoBehaviour
    {
        public Action<Levels> onLoad;
        private CanvasGroup loadingScreen;
        [Range(0.0f, 0.01f)]
        [SerializeField] private float _fadeSpeed;
        private float _fadeOutStart = 0;
        private float _fadeInStart = 1;

        void Awake()
        {
            CanvasGroupSetUp();
            StartCoroutine(LoadScene(Levels.level1Platforming));
        }

        public IEnumerator LoadScene(Levels targetLevel)
        {
            //TO DO:Change state from playing to loading
            yield return StartCoroutine(FadeScreenOut(_fadeOutStart, _fadeSpeed));
            //The new level gets loaded
            SceneManager.LoadScene(targetLevel.ToString());
            //The new level is loaded, and it'll begin to fade out.
            yield return StartCoroutine(FadeScreenIn(_fadeInStart, _fadeSpeed));
            onLoad?.Invoke(targetLevel);
            yield return null;
        }
        
        private IEnumerator FadeScreenIn(float x, float z)
        {
            while (x > 0)
            {
                x -= z;
                loadingScreen.alpha = x;
                yield return null;
            }
            loadingScreen.alpha = 0;
            yield return null;
        }

        private IEnumerator FadeScreenOut(float x, float z)
        {
            while (x < 1)
            {
                x += z;
                loadingScreen.alpha = x;
                yield return null;
            }
            loadingScreen.alpha = 1;
            yield return null;
        }

        private void CanvasGroupSetUp()
        {
            loadingScreen = GetComponentInChildren<CanvasGroup>();
            loadingScreen.alpha = 1;
            loadingScreen.interactable = false;
            loadingScreen.blocksRaycasts = false;
            StartCoroutine(FadeScreenIn(loadingScreen.alpha, _fadeSpeed));
        }
    }
}