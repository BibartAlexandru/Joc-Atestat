using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    private AudioSource audioSource;
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
        audioSource = player.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        base.Enter();
        audioSource.clip = player.wallSlideSound;
        audioSource.Play();
        player.transform.Find("Corp").GetComponent<SpriteRenderer>().sprite = playerData.reversedSprite; 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityY(playerData.wallSlideVelocity);
        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void Exit()
    {
        player.transform.Find("Corp").GetComponent<SpriteRenderer>().sprite = playerData.regularSprite;
        audioSource.Stop();
    }
}
