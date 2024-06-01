using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_IdleState : IdleState
{
    private Bomber enemy;
    private AudioSource audioSource;
    public Bomber_IdleState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_IdleState _stateData ,Bomber _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
        audioSource = enemy.transform.GetComponent<AudioSource>();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInSmallAgroRange)
            stateMachine.ChangeState(enemy.explosionState);
        else if (isPlayerInBigAgroRange)
        {
            audioSource.PlayOneShot(enemy.entityData.foundPlayer);
            enemy.playerDetectedState.ChangeAnimation("PlayerDetected");
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isIdleTimeOver)
            stateMachine.ChangeState(enemy.moveState);
    }
}
