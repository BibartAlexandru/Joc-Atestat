using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : Entity
{
    public Walker_IdleState idleState { get; private set; }
    public Walker_MoveState moveState { get; private set; }
    public Walker_ChargeState chargeState { get; private set; }

    public Walker_PlayerDetectedState playerDetectedState { get; private set; }

    public Walker_MeleeAttackState meleeAttackState { get; private set; }

    public Walker_DeadState deadState { get; private set; }

    Animator squashAnimator;

    [SerializeField]
    private D_IdleState idleStataData;
    [SerializeField]
    private D_MoveState movestateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private D_DeadState deadStateData;

    public override void Awake()
    {
        base.Awake();

        moveState = new Walker_MoveState(this, stateMachine, "Enemy1Walk", movestateData, this);
        idleState = new Walker_IdleState(this, stateMachine, "Enemy1Idle", idleStataData, this);
        playerDetectedState = new Walker_PlayerDetectedState(this, stateMachine, "Enemy1PlayerDetected", playerDetectedData, this);
        chargeState = new Walker_ChargeState(this, stateMachine, "Enemy1ChargePlayer", chargeStateData, this);
        meleeAttackState = new Walker_MeleeAttackState(this, stateMachine, "Enemy1MeleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new Walker_DeadState(this, stateMachine, "Enemy1Death", deadStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState); 
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void SwitchToDeadState()
    {
        base.SwitchToDeadState();
        stateMachine.ChangeState(deadState);
    }

    public override void SwitchToAliveState()
    {
        base.SwitchToAliveState();
        stateMachine.ChangeState(idleState);
    }
    public override void Update()
    {
        base.Update();
    }

    public override void DoTouchDamage(GameObject player)
    {
        base.DoTouchDamage(player);
        stateMachine.ChangeState(playerDetectedState);
    }
}
