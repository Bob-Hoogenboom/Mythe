using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

public class PlayerManager : MonoBehaviour
{
    private Action<float> moveDelegate;
    public Action<float> currentMovement;
    public Action<float> combatMovement;
    public Action<float> towerMovement;

    private float inputDir;

    private PlayerController combatMovementCode;
    private PlayerMove towerMovementCode;

    private float playerInput;

    void Start()
    {
        combatMovementCode = GetComponentInChildren<PlayerController>();
        towerMovementCode = GetComponentInChildren<PlayerMove>();

        combatMovement += (inputDir) =>
        {
            combatMovementCode.MoveCharacter(inputDir);
        };

        towerMovement += (inputDir) =>
        {
            towerMovementCode.CharacterMovement(inputDir);
        };
    }

    void Update()
    {
        moveDelegate?.Invoke(InputParse());
    }

    private float InputParse()
    {
        return Input.GetAxisRaw("horizontal");
    }


    /*    private void setMovementFunc(LevelType targetLevel)
        {
            switch (targetLevel)
            {
                case LevelType.Platformer:
                    break;
                case LevelType.Combat:
                    break;
            }
        }*/
}
