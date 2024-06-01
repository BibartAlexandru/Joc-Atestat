using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monoculus_PlayerDetectedState : PlayerDetectedState
{
    Monoculus enemy;
    public Monoculus_PlayerDetectedState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_PlayerDetected _stateData,Monoculus _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (performLongRangeAction)
            stateMachine.ChangeState(enemy.chaseState);
    }
}
