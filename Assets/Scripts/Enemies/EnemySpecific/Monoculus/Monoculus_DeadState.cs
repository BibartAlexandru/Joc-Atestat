using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monoculus_DeadState : DeadState
{
    Monoculus enemy;
    public Monoculus_DeadState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_DeadState _stateData,Monoculus _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }
}
