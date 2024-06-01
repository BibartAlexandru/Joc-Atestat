using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttackState stateData;
    protected AttackDetails attackDetails;
    public MeleeAttackState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, Transform _atatckPosition,D_MeleeAttackState _stateData) : base(_entity, _stateMachine, _animation, _atatckPosition)
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
        entity.lastMeleeAttackTime = -1f; 
        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.transform.position;
        attackDetails.knockBackForce = stateData.knockBackForce;
        attackDetails.knockBackTime = stateData.knockBackTime;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        entity.lastMeleeAttackTime = Time.time;
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position,stateData.attackRadius,stateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.GetComponent<IDamageable>() != null)
                collider.GetComponent<IDamageable>().Damage(attackDetails);
        }
    }
}
