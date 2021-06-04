using System;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        Timer timer;
        LevelLoader levelLoader;
        PlayerManager playerSystem;

        private Levels currenLevel;
        private GameState currentState;
        
        private Dictionary<Levels,Action<LevelType>> myLevelIndex = new Dictionary<Levels, Action<LevelType>>();

        public float requestedTime;


        private void Start()
        {
            timer = FindObjectOfType<Timer>();
            levelLoader = FindObjectOfType<LevelLoader>();
            playerSystem = FindObjectOfType<PlayerManager>();

            levelLoader.onLoad += (loadedLevel) =>
            {
                UpdateState(GameState.Playing);
                /*CheckNewLevel(loadedLevel);*/
            };  

            DontDestroyOnLoad(levelLoader);
            DontDestroyOnLoad(timer);
            DontDestroyOnLoad(this);

            currenLevel = Levels.MainMenu;
            UpdateState(GameState.MainMenu);

            myLevelIndex.Add(Levels.level1Platforming, setMovement(targetLevel: LevelType));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UpdateState(GameState.Loading);
                StartCoroutine(levelLoader.LoadScene(Levels.level1Platforming));
            }
        }

        private void UpdateState(GameState newState)
        {
            currentState = newState;

            switch (newState)
            {
                case GameState.MainMenu:
                    timer.SetTimer(requestedTime);
                    Debug.Log("Game Start");
                    break;
                case GameState.Loading:
                    timer.PauseTimer();
                    Debug.Log("Timer Paused, currently loading");
                    break;
                case GameState.Paused:
                    break;
                case GameState.Playing:
                    Debug.Log("Timer active, load complete");
                    timer.StartTimer();
                    break;
            }
            Debug.Log(newState.ToString());
        }

        private void OnLoadCallBack()
        {
            UpdateState(GameState.Playing);
        }

        private Action setMovement(LevelType targetLevel)
        {
            switch(targetLevel)
            {
                case LevelType.Platformer:
                    playerSystem.currentMovement = playerSystem.towerMovement;
                    break;
                case LevelType.Combat:
                    playerSystem.currentMovement = playerSystem.combatMovement;
                    break;
                default:
                    break;
            }
            return null;
        }

    }
}