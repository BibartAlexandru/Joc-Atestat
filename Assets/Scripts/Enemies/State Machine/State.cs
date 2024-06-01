using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    protected Core core;
    public float startTime { get; protected set; }

    protected string animation;

    public State(Entity _entity,FiniteStateMachine _stateMachine,string _animation)
    {
        entity = _entity;
        stateMachine = _stateMachine;
        animation = _animation;
        core = entity.core;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.animator.Play(animation);
        DoChecks();
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public void ChangeAnimation(string newAnimation)
    {
        animation = newAnimation;
    }

    public virtual void DoChecks()
    {

    }
}
