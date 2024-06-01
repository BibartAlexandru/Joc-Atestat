using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public void Enter()
    {
        core.Movement.SetVelocity(0, Vector2.zero, 1);
        isAnimationFinished = false;
        Debug.Log("Entered landing");
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAnimationFinished = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
