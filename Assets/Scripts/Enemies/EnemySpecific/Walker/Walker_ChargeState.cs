using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker_ChargeState : ChargeState
{
    private Walker enemy;
    private AudioSource audioSource;
    public Walker_ChargeState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_ChargeState _stateData,Walker _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
        audioSource = enemy.transform.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        base.Enter();
        audioSource.clip = enemy.entityData.chase;
        audioSource.Play();
    }

    public override void Exit()
    {
        base.Exit();
        audioSource.clip = null;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isChargeTimeOver)
        {
            if (performCloseRangeAction && Time.time > enemy.lastMeleeAttackTime + enemy.entityData.meleeAttackCooldown)
            {
                stateMachine.ChangeState(enemy.meleeAttackState);
            }
            else if (isPlayerInBigAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
        else if (performCloseRangeAction && Time.time > enemy.lastMeleeAttackTime + enemy.entityData.meleeAttackCooldown)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
