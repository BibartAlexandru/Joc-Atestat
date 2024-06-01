using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monoculus_IdleState : IdleState
{
    Monoculus enemy;
    bool isGrounded;
    public Monoculus_IdleState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_IdleState _stateData,Monoculus _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = core.CollisionSenses.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocity(0, Vector2.zero, 1);
        core.Movement.ChangeStopMovementForAmountOfTime(true,1.2f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInSmallAgroRange)
            stateMachine.ChangeState(enemy.playerDetectedState);
        else if (isGrounded)
            stateMachine.ChangeState(enemy.riseState);
    }
}
