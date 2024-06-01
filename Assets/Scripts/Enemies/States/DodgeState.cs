using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    protected D_DodgeState stateData;
    protected bool performCloseRangeAction;
    protected bool isPlayerinBigAgroRange;
    protected bool isGrounded;
    protected bool isDodgeOver;
    public DodgeState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_DodgeState _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerinBigAgroRange = entity.CheckPlayerInBigAgroRange();
        isGrounded = core.CollisionSenses.CheckIfGrounded();

    }

    public override void Enter()
    {
        base.Enter();
        isDodgeOver = false;
        core.Movement.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle, -core.Movement.facingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.dodgeTime)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //entity.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle, -entity.facingDirection);
    }
}
