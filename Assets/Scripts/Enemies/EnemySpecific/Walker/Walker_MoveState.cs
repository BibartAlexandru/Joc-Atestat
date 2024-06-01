using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker_MoveState : MoveState
{
    private Walker enemy;
    public Walker_MoveState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_MoveState _stateData,Walker _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInSmallAgroRange)
        {
            audioSource.PlayOneShot(enemy.entityData.foundPlayer);
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (!isDetectingLedge || isDetectingWall)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.facingDirection);
    }
}
