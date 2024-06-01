using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;
    protected bool isPlayerInSmallAgroRange;
    protected bool isPlayerInBigAgroRange;
    protected bool isFacingPlayer;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;
    protected int chargeDirection = 1;

    public ChargeState(Entity _entity, FiniteStateMachine _stateMachine, string _animation,D_ChargeState _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInSmallAgroRange = entity.CheckPlayerInSmallAgroRange();
        isFacingPlayer = core.Movement.isFacingPlayer();
        isDetectingLedge = core.CollisionSenses.CheckLedge();
        isDetectingWall = core.CollisionSenses.CheckIfTouchingWall();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInBigAgroRange = entity.CheckPlayerInBigAgroRange();
        isFacingPlayer = core.Movement.isFacingPlayer();
        if (!isFacingPlayer)
            core.Movement.Flip();
    }

    public override void Enter()
    {
        base.Enter();
        chargeDirection = core.Movement.facingDirection;
        core.Movement.SetVelocityX(stateData.chargeSpeed*chargeDirection);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        isPlayerInSmallAgroRange = entity.CheckPlayerInSmallAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInBigAgroRange = entity.CheckPlayerInBigAgroRange();
        core.Movement.SetVelocityX(stateData.chargeSpeed*chargeDirection);
    }
}
