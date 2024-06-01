using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_DeadState : DeadState
{
    private Shooter enemy;
    public Shooter_DeadState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_DeadState _stateData, Shooter _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void DestroyObject()
    {
        base.DestroyObject();
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
