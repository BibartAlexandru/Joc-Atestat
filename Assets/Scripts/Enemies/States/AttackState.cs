using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected Transform attackPosition; 
    protected bool isAnimationFinished;
    protected bool isPlayerInSmallAgroRange;
    protected bool isPlayerInBigAgroRange;

    public AttackState(Entity _entity, FiniteStateMachine _stateMachine, string _animation,Transform _atatckPosition) : base(_entity, _stateMachine, _animation)
    {
        attackPosition = _atatckPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInSmallAgroRange = entity.CheckPlayerInSmallAgroRange();
        isPlayerInBigAgroRange = entity.CheckPlayerInBigAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;
        entity.animationToStateMachine.attackState = this;
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
    }

    public virtual void TriggerAttack()
    {
    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
