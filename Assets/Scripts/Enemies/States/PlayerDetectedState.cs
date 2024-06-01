using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerInSmallAgroRange;
    protected bool isPlayerInBigAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;

    public PlayerDetectedState(Entity _entity, FiniteStateMachine _stateMachine, string _animation,D_PlayerDetected _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInSmallAgroRange = entity.CheckPlayerInSmallAgroRange();
        isPlayerInBigAgroRange = entity.CheckPlayerInBigAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        if (!core.Movement.isFacingPlayer())
            core.Movement.Flip();
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(0);
        performLongRangeAction = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityX(0);
    }
}
