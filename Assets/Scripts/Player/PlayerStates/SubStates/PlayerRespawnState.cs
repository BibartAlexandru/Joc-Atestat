using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRespawnState : PlayerState
{
    public PlayerRespawnState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public override void Enter()
    {
        base.Enter();
        GameObject.Instantiate(playerData.respawnParticle, player.transform.position, Quaternion.identity);
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        core.Combat.RestoreHP();
        core.Movement.SetStopMovement(false);
        player.gameObject.SetActive(false);
    }

}
