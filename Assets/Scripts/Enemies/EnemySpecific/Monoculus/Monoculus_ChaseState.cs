using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monoculus_ChaseState : ChargeState
{
    Monoculus enemy;
    public Monoculus_ChaseState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_ChargeState _stateData,Monoculus _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isPlayerInBigAgroRange)
            stateMachine.ChangeState(enemy.idleState);
    }

    public override void DoChecks()
    {
        isPlayerInSmallAgroRange = entity.CheckPlayerInSmallAgroRange();
        isFacingPlayer = core.Movement.isFacingPlayer();
        isDetectingLedge = core.CollisionSenses.CheckLedge();
        isDetectingWall = core.CollisionSenses.CheckIfTouchingWall();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInBigAgroRange = entity.CheckPlayerInBigAgroRange();
        isFacingPlayer = core.Movement.isFacingPlayer();
        if (!isFacingPlayer)
        {
            core.Movement.Flip();
            core.Movement.SetVelocity(0, Vector2.zero,1);
            core.Movement.ChangeStopMovementForAmountOfTime(true, 0.2f);
        }
    }

    public override void Enter()
    {
        isChargeTimeOver = false;
        startTime = Time.time;
        entity.animator.Play(animation);
        DoChecks();
    }

    public override void PhysicsUpdate()
    {
        DoChecks();
        core.Movement.SetVelocity(stateData.chargeSpeed, (Vector2)enemy.Player.transform.position - (Vector2)core.transform.position, 1);
    }
}
