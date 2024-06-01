using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_ExplosionState : AttackState
{
    private Bomber enemy;
    public Bomber_ExplosionState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, Transform _atatckPosition, Bomber _enemy) : base(_entity, _stateMachine, _animation, _atatckPosition)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.core.Combat.SetKnockBackForceResistance(Mathf.Infinity);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.core.Combat.SetKnockBackForceResistance(enemy.entityData.knockBackForceResistance);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            enemy.playerDetectedState.ChangeAnimation("LookingAtPlayer");
            stateMachine.ChangeState(enemy.recoveryState);
        }
    }
}
