using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInSmallAgroRange;
    protected bool isPlayerInBigAgroRange;

    protected float idleTime;
    public IdleState(Entity _entity, FiniteStateMachine _stateMachine, string _animation,D_IdleState _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
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
        isIdleTimeOver = false;
        core.Movement.SetVelocityX(0f);
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            core.Movement.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityX(0f);
    }

    public void SetFlipAfterIdle(bool verdict)
    {
        flipAfterIdle = verdict;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime,stateData.maxIdleTime);
    }
}
