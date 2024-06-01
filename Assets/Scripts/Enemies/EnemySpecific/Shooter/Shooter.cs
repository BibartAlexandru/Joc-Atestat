using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Entity
{
    public Shooter_MoveState moveState { get; private set; }
    public Shooter_IdleState idleState { get; private set; }

    public Shooter_MeleeAttackState meleeAttackState { get; private set; }
    public Shooter_PlayerDetectedState playerDetectedState { get; private set; }

    public Shooter_DeadState deadState { get; private set; }

    public Shooter_DodgeState dodgeState { get; private set; }
    

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_MeleeAttackState meleeAttackStateData;
    [SerializeField] private Transform meleeAttackPosition;
    [SerializeField] public GameObject attackEffect;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] public D_DodgeState dodgeStateData;

    public override void Awake()
    {
        base.Awake();

        moveState = new Shooter_MoveState(this, stateMachine, "ShooterMove", moveStateData, this);
        idleState = new Shooter_IdleState(this, stateMachine, "ShooterIdle", idleStateData, this);
        playerDetectedState = new Shooter_PlayerDetectedState(this, stateMachine, "ShooterPlayerDetected", playerDetectedStateData, this);
        meleeAttackState = new Shooter_MeleeAttackState(this, stateMachine, "ShooterMeleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new Shooter_DeadState(this, stateMachine, "ShooterDeath",deadStateData,this);
        dodgeState = new Shooter_DodgeState(this, stateMachine, "ShooterDodge", dodgeStateData, this);
        

        stateMachine.Initialize(idleState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log(stateMachine.currentState.ToString());
    }
}
