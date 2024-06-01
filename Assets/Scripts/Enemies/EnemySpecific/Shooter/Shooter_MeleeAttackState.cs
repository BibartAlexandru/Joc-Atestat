using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_MeleeAttackState : MeleeAttackState
{
    private Shooter enemy;
    public Shooter_MeleeAttackState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, Transform _atatckPosition, D_MeleeAttackState _stateData,Shooter _enemy) : base(_entity, _stateMachine, _animation, _atatckPosition, _stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInBigAgroRange)
                stateMachine.ChangeState(enemy.playerDetectedState);
            else
                stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        GameObject.Instantiate(enemy.attackEffect, attackPosition.position,enemy.transform.rotation);
    }
}
