using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;
    public DeadState deadState;
    public MoveState moveState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    private void DestroyObject()
    {
        deadState.DestroyObject();
    }

    private void StartMovement()
    {
        moveState.StartMovement();
    }

    private void StopMovement()
    {
        moveState.StopMovement();
    }
}
