using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInSmallAgroRange;
    protected bool isPlayerInBigAgroRange;
    protected float lastTimeSpawnedFootStepParticle = 0f;

    protected AudioSource audioSource;

    public MoveState(Entity _entity, FiniteStateMachine _stateMachine, string _animation,D_MoveState _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
        audioSource = entity.transform.gameObject.GetComponent<AudioSource>();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = core.CollisionSenses.CheckLedge();
        isDetectingWall = core.CollisionSenses.CheckIfTouchingWall();
        isPlayerInSmallAgroRange = entity.CheckPlayerInSmallAgroRange();
        isPlayerInBigAgroRange = entity.CheckPlayerInBigAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        audioSource.clip = entity.entityData.walk;
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
        if (Physics2D.OverlapCircle(entity.core.CollisionSenses.groundCheck.position, entity.core.CollisionSenses.groundCheckRadius, entity.mazgaLayer) && lastTimeSpawnedFootStepParticle + entity.footSpedParticleCooldown <= Time.time)
        {
            GameObject.Instantiate(entity.mazgaFootStepParticle, entity.core.CollisionSenses.GroundCheck.position, Quaternion.identity);
            lastTimeSpawnedFootStepParticle = Time.time;
        }
    }

    public void StartMovement()
    {
        core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.facingDirection);
    }

    public void StopMovement()
    {
        core.Movement.SetVelocityX(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityX(stateData.movementSpeed*core.Movement.facingDirection);
    }
}
