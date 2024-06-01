using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monoculus : Entity
{
    #region State Variables
    public Monoculus_IdleState idleState { get; private set; }
    public Monoculus_ChaseState chaseState { get; private set; }
    public Monoculus_DeadState deadState { get; private set; }
    public Monoculus_PlayerDetectedState playerDetectedState { get; private set; }
    public Monoculus_RiseState riseState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_ChargeState chaseStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_MoveState riseStateData;

    #endregion

    #region Unity Callback Functions
    public override void Awake()
    {
        base.Awake();
        idleState = new Monoculus_IdleState(this, stateMachine, "Idle", idleStateData, this);
        chaseState = new Monoculus_ChaseState(this, stateMachine, "Chase", chaseStateData, this);
        deadState = new Monoculus_DeadState(this, stateMachine, "Dead", deadStateData, this);
        playerDetectedState = new Monoculus_PlayerDetectedState(this, stateMachine, "PlayerDetected", playerDetectedStateData, this);
        riseState = new Monoculus_RiseState(this, stateMachine, "Idle", riseStateData, this);
    }
    #endregion

    public void Start()
    {
        stateMachine.Initialize(idleState);
    }

    #region Other Functions
    public override void SwitchToDeadState()
    {
        stateMachine.ChangeState(deadState);
    }
    #endregion

}
