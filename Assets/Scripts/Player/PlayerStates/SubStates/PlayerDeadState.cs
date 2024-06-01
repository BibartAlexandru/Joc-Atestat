using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public override void Enter()
    { 
        base.Enter();
        //player.playerDeathScreenAnimator.Play("PlayerDeathScreenBegin");
        player.currentAudioListenerAfterDeath = Instantiate(player.audioListenerCandMoare, player.transform.position, Quaternion.identity);
        core.Movement.SetVelocity(0, Vector2.zero, 1);
        core.Movement.SetStopMovement(true);
    }
}
