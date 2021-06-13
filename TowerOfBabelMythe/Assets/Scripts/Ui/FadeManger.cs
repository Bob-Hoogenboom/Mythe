using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Ui
{
    public class FadeManger : MonoBehaviour
    {
        public CanvasGroup loadingScreen;
        [Range(0.0f, 0.01f)]
        public float _fadeSpeed;
        private float _fadeOutStart = 0;
        private float _fadeInStart = 1;

        private void Start()
        {
            CanvasGroupSetUp();    
        }

        private void CanvasGroupSetUp()
        {
            loadingScreen = GetComponentInChildren<CanvasGroup>();
            loadingScreen.alpha = 1;
            loadingScreen.interactable = false;
            loadingScreen.blocksRaycasts = false;
        }

        public IEnumerator FadeScreenIn(float x, float z)
        {
            Debug.Log("Beginning");
            while (x > 0)
            {
                x -= z;
                loadingScreen.alpha = x;
                yield return null;
            }
            loadingScreen.alpha = 0;
            yield return null;
            Debug.Log("Complete");
        }

        public IEnumerator FadeScreenOut(float x, float z)
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
    }
}