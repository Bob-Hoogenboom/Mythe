using System;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        public LevelData[] levelDatas;
        Ui.FadeManger fadeManger;
        Timer timer;
        LevelLoader levelLoader;
        PlayerManager playerManager;

        private int _currentLevelIndex;
        private GameState currentState = GameState.MainMenu;
        public float requestedTime;

        private void Start()
        {
            DontDestroySetUp();
            levelLoader.onLoad += (loadedLevel) =>
            {
                UpdateState(GameState.Playing);
            };
            InitialFadeIn();
            UpdateState(GameState.MainMenu);
            FindObjectOfType<AudioManager>().Play(SoundLibrary.Sounds.BGM);
        }

        private void Update()
        {
           if(Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine("LoadLevel", levelDatas[0]);
            }
        }

        private void UpdateState(GameState newState)
        {
            switch (newState)
            {
                case GameState.MainMenu:
                    timer.SetTimer(requestedTime);
                    break;

                case GameState.Loading:
                    timer.PauseTimer();
                    break;

                case GameState.Paused:
                    timer.PauseTimer();
                    break;

                case GameState.Playing:
                    timer.StartTimer();
                    break;
            }
        }

        private IEnumerator LoadLevel(LevelData targetLevel)
        {
            if(playerManager != null)
            {
                playerManager.inControl = false;
            }

            UpdateState(GameState.Loading);

            yield return fadeManger.StartCoroutine(fadeManger.FadeScreenOut(fadeManger._fadeSpeed));

            yield return levelLoader.StartCoroutine(levelLoader.LoadScene(targetLevel.level));

            LevelManager loadingLevel = FindObjectOfType<LevelManager>();
            Debug.Log(loadingLevel);
            loadingLevel.onLevelCompletion += OnLevelCompletion;
/*            loadingLevel.CountingEnemies();*/
            _currentLevelIndex = targetLevel.index;

            yield return fadeManger.StartCoroutine(fadeManger.FadeScreenIn(fadeManger._fadeSpeed));

            playerManager = FindObjectOfType<PlayerManager>();
            playerManager.inControl = true;

            UpdateState(GameState.Playing);
            yield return null;
        }

        public void LoadFirstLevel()
        {
            StartCoroutine("LoadLevel", levelDatas[0]);
            timer.currentTime = requestedTime + 1;
        }

        private void DontDestroySetUp()
        {
            fadeManger = FindObjectOfType<Ui.FadeManger>();
            timer = FindObjectOfType<Timer>();
            levelLoader = FindObjectOfType<LevelLoader>();

            DontDestroyOnLoad(fadeManger);
            DontDestroyOnLoad(levelLoader);
            DontDestroyOnLoad(timer);
            DontDestroyOnLoad(this);
        }

        private void InitialFadeIn()
        {
            fadeManger.loadingScreen.alpha = 1;
            fadeManger.StartCoroutine(fadeManger.FadeScreenIn(fadeManger._fadeSpeed));
        }

        private void OnLevelCompletion()
        {
            StartCoroutine("LoadLevel", levelDatas[_currentLevelIndex + 1]);
        }
    }
}

[Serializable]
public class LevelData
{
    public Levels level;
    public int index;

    public LevelData(Levels level, int index, bool isCombat)
    {
        this.level = level;
        this.index = index;
    }
}