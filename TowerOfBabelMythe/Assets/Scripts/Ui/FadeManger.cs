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
            loadingScreen.interactable = false;
            loadingScreen.blocksRaycasts = false;
        }

        public IEnumerator FadeScreenIn(float z)
        {
            while (loadingScreen.alpha > 0)
            {
                loadingScreen.alpha -= z;
                yield return null;
            }
            loadingScreen.alpha = 0;
            yield return null;
        }

        public IEnumerator FadeScreenOut(float z)
        {
            while (loadingScreen.alpha < 1)
            {
                loadingScreen.alpha += z;
                yield return null;
            }
            loadingScreen.alpha = 1;
            yield return null;
        }
    }
}