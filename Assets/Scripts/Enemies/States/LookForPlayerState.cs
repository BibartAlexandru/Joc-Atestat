using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayerState stateData;
    protected bool turnImmediately = false;
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;

    protected float lastTurnTime;

    protected int amountOfTurnsDone;
    public LookForPlayerState(Entity _entity, FiniteStateMachine _stateMachine, string _animation,D_LookForPlayerState _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInSmallAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInBigAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isAllTurnsTimeDone = false;
        isAllTurnsDone = false;
        amountOfTurnsDone = 0;
        lastTurnTime = Time.time;
        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (turnImmediately)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImmediately = false;
        }
        else if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        if(amountOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityX(0f);
    }

    public virtual void SetTurnImmediately(bool verdict)
    {
        turnImmediately = verdict;
    }
}
