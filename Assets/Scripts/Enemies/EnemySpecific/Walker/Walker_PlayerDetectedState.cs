using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker_PlayerDetectedState : PlayerDetectedState
{
    private Walker enemy;
    private AudioSource audioSource;
    public Walker_PlayerDetectedState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_PlayerDetected _stateData,Walker _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
        audioSource = enemy.transform.GetComponent<AudioSource>();
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
        if (performCloseRangeAction && Time.time > enemy.meleeAttackState.startTime+enemy.entityData.meleeAttackCooldown)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.chargeState);
        }
        else if (!isPlayerInBigAgroRange)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
