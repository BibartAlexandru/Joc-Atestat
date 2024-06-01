using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryState : State
{
    protected bool isRecoveryFinished;
    protected D_RecoveryStateData stateData;
    public RecoveryState(Entity _entity, FiniteStateMachine _stateMachine, string _animation,D_RecoveryStateData _stateData) : base(_entity, _stateMachine, _animation)
    {
        stateData = _stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isRecoveryFinished = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.recoveryTime)
            isRecoveryFinished = true;
    }

    public void SetRecovery(bool verdict)
    {
        isRecoveryFinished = verdict;
    }
}
