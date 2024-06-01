using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_PlayerDetectedState : PlayerDetectedState
{
    private Bomber enemy;
    public Bomber_PlayerDetectedState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_PlayerDetected _stateData,Bomber _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInSmallAgroRange)
            stateMachine.ChangeState(enemy.explosionState);
        else if (performLongRangeAction)
            stateMachine.ChangeState(enemy.handAttackState);
        else if (!isPlayerInBigAgroRange)
            stateMachine.ChangeState(enemy.idleState);
    }
}
