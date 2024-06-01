using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_PlayerDetectedState : PlayerDetectedState
{
    private Shooter enemy;
    public Shooter_PlayerDetectedState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_PlayerDetected _stateData,Shooter _enemy) : base(_entity, _stateMachine, _animation, _stateData)
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
        if (performCloseRangeAction)
        {
            if (Time.time >= enemy.dodgeState.startTime + enemy.dodgeStateData.dodgeCooldown)
                stateMachine.ChangeState(enemy.dodgeState);
            else if(Time.time >= enemy.meleeAttackState.startTime + enemy.entityData.meleeAttackCooldown)
                stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (!isPlayerInBigAgroRange)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
}
