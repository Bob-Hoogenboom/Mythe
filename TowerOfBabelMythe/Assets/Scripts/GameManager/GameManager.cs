using System;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] LevelData[] levelDatas;
        Ui.FadeManger fadeManger;
        Timer timer;
        LevelLoader levelLoader;
        PlayerManager playerManager;

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

        private void LoadFirstLevel(LevelData targetLevel)
        {
            if(playerManager != null)
            {
                playerManager.inControl = false;
            }

            UpdateState(GameState.Loading);

            timer.currentTime = requestedTime;
            fadeManger.StartCoroutine(fadeManger.FadeScreenOut(fadeManger._fadeSpeed));

            levelLoader.StartCoroutine(levelLoader.LoadScene(targetLevel.level));
            LevelManager loadingLevel = FindObjectOfType<LevelManager>();
            loadingLevel.onLevelCompletion += OnLevelCompletion;
            loadingLevel.CountingEnemies();

            fadeManger.StartCoroutine(fadeManger.FadeScreenIn(fadeManger._fadeSpeed));
            playerManager = FindObjectOfType<PlayerManager>();
            playerManager.inControl = true;

            UpdateState(GameState.Playing);
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

        }
    }
}

[Serializable]
public class LevelData
{
    public Levels level;
    [SerializeField]private int index;

    public LevelData(Levels level, int index, bool isCombat)
    {
        this.level = level;
        this.index = index;
    }
}