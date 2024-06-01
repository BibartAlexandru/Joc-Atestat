using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmptyState : PlayerState
{
    public PlayerEmptyState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {

    }
}
