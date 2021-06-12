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
            fadeManger = FindObjectOfType<Ui.FadeManger>();
            timer = FindObjectOfType<Timer>();
            levelLoader = FindObjectOfType<LevelLoader>();

            levelLoader.onLoad += (loadedLevel) =>
            {
                UpdateState(GameState.Playing);
            };

            DontDestroyOnLoad(fadeManger);
            DontDestroyOnLoad(levelLoader);
            DontDestroyOnLoad(timer);
            DontDestroyOnLoad(this);
            UpdateState(GameState.MainMenu);

            fadeManger.StartCoroutine(fadeManger.FadeScreenIn(fadeManger.loadingScreen.alpha, fadeManger._fadeSpeed));
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
    }
}

[Serializable]
public class LevelData
{
    public Levels level;
    private int index;
    public bool isCombat;

    public LevelData(Levels level, int index, bool isCombat)
    {
        this.level = level;
        this.index = index;
        this.isCombat = isCombat;
    }
}