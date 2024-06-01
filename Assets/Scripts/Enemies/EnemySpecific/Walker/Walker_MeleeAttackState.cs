using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker_MeleeAttackState : MeleeAttackState
{
    private Walker enemy;
    private AudioSource audioSource;
    public Walker_MeleeAttackState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, Transform _atatckPosition, D_MeleeAttackState _stateData,Walker _enemy) : base(_entity, _stateMachine, _animation, _atatckPosition, _stateData)
    {
        enemy = _enemy;
        audioSource = enemy.transform.GetComponent<AudioSource>();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        audioSource.PlayOneShot(enemy.entityData.attack1);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            if (isPlayerInBigAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
