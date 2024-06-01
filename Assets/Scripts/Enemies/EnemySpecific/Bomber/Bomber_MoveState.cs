using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_MoveState : MoveState
{
    private Bomber enemy;
    private AudioSource audioSource;
    public Bomber_MoveState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_MoveState _stateData,Bomber _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
        enemy.animationToStateMachine.moveState = this;
        audioSource = enemy.transform.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInBigAgroRange)
        {
            audioSource.PlayOneShot(enemy.entityData.foundPlayer);
            enemy.playerDetectedState.ChangeAnimation("PlayerDetected");
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (core.CollisionSenses.CheckIfTouchingWall() || !core.CollisionSenses.CheckLedge())
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
