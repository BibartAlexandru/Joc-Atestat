using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monoculus_MoveState : MoveState
{
    Monoculus enemy;
    public Monoculus_MoveState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_MoveState _stateData, Monoculus _enemy ) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    
}
