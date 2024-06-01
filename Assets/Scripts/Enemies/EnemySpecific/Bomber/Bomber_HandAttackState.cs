using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_HandAttackState : AttackState
{
    private Bomber enemy;
    private int destroyedSpikes;
    private bool hasAttackStarted = false;
    private float lastTimeSpawnedSpike;
    private Vector2 lastSpikePosition;
    private float spikesSpawned;
    private bool once;
    public Bomber_HandAttackState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, Transform _atatckPosition,Bomber _enemy) : base(_entity, _stateMachine, _animation, _atatckPosition)
    {
        enemy = _enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.core.Combat.SetKnockBackForceResistance(Mathf.Infinity);
        lastSpikePosition = default;
        spikesSpawned = 0;
        destroyedSpikes = 0;
        hasAttackStarted = false;
        once = false;
    }

    public override void Exit()
    {
        base.Exit();
        enemy.core.Combat.SetKnockBackForceResistance(enemy.entityData.knockBackForceResistance);
        enemy.StopSmoke();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (hasAttackStarted && Time.time > lastTimeSpawnedSpike + enemy.timeBetweenSpikeSpawn && spikesSpawned < 6)
        {
            lastTimeSpawnedSpike = Time.time;
            spikesSpawned++;
            GameObject gm = GameObject.Instantiate(enemy.spike, GetNextSpikePosition(), Quaternion.identity);
                gm.GetComponentInChildren<Spike>().GetParent(enemy.gameObject);      
        }
        else if(destroyedSpikes == 6)
        {
            if (once == false)
            {
                enemy.animator.Play("HandAttackRecovery");
                once = true;
            }
            if (isAnimationFinished)
            {
                if (!isPlayerInBigAgroRange)
                    stateMachine.ChangeState(enemy.recoveryState);
                else
                {
                    enemy.playerDetectedState.ChangeAnimation("LookingAtPlayer");
                    stateMachine.ChangeState(enemy.recoveryState);
                }
            }
        }
    }

    public void AddDestroyedSpikes()
    {
        destroyedSpikes++;
    }

    public Vector2 GetNextSpikePosition()
    {
        if(lastSpikePosition == default)
        {
            lastSpikePosition = (Vector2)enemy.transform.position + new Vector2(Random.Range(enemy.distanceFromFirstSpikeMin.x,enemy.distanceFromFirstSpikeMax.x)*enemy.core.Movement.facingDirection,0f);
            lastSpikePosition = GetYPositionWhereSpikeCanSpawn(lastSpikePosition);
        }
        lastSpikePosition += enemy.distanceBetweenSpikes*enemy.core.Movement.facingDirection;
        lastSpikePosition = lastSpikePosition = GetYPositionWhereSpikeCanSpawn(lastSpikePosition);
        return lastSpikePosition;
    }

    public Vector2 GetYPositionWhereSpikeCanSpawn(Vector2 result)
    {
        //result.y = enemy.Player.transform.position.y;
        while (Physics2D.OverlapCircle(result, .1f, enemy.canSpawnSpike) == null)
            result.y -= .3f;
        while (Physics2D.OverlapCircle(result, .1f, enemy.canSpawnSpike) != null)
            result.y += .2f;
        result.y -= .3f;
        return result;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        hasAttackStarted = true;
    }
}
