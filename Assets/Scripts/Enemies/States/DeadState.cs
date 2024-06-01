using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    D_DeadState stateData;
    public DeadState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_DeadState _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        foreach(GameObject destroyEffect in stateData.destroyEffects)
            GameObject.Instantiate(destroyEffect, entity.TopOfHead.position, Quaternion.identity);
        entity.animationToStateMachine.deadState = this;
        //entity.gameObject.SetActive(false);
        GameObject.Destroy(core.transform.parent.gameObject);
        core.Movement.SetVelocityX(0f);
        core.Movement.SetStopMovement(true);
    }

    public virtual void DestroyObject()
    {
        //GameObject.Instantiate(destroyEffect, entity.transform.position, Quaternion.identity);
        entity.gameObject.SetActive(false);
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
