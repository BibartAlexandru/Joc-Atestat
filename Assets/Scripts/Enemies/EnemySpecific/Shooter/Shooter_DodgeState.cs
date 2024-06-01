using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_DodgeState : DodgeState
{
    private Shooter enemy;
    public Shooter_DodgeState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_DodgeState _stateData,Shooter _enemy) : base(_entity, _stateMachine, _animation, _stateData)
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
        if (isDodgeOver)
        {
            if (performCloseRangeAction && Time.time > enemy.meleeAttackState.startTime + enemy.entityData.meleeAttackCooldown)
                stateMachine.ChangeState(enemy.meleeAttackState);
            else if (!isPlayerinBigAgroRange)
                stateMachine.ChangeState(enemy.idleState);
            else
                stateMachine.ChangeState(enemy.playerDetectedState);
            //Ranged attack state transition pls!
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
