using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_DeadState : DeadState
{
    private Bomber enemy;
    public Bomber_DeadState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_DeadState _stateData,Bomber _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }
}
