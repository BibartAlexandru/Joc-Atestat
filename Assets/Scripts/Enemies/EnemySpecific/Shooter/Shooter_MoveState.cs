using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_MoveState : MoveState
{
    private Shooter enemy;
    public Shooter_MoveState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_MoveState _stateData,Shooter _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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
       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (isPlayerInSmallAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (!core.CollisionSenses.CheckLedge() || core.CollisionSenses.CheckIfTouchingWall())
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
