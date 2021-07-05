using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Suspicion", 1000);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Suspicion", -1);
        //Een functie waar die rond gaat lopen
        //Een functie waar die kijkt of hij de speler spot
    }
}
