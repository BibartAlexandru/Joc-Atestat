using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int xInput;
    private float yInput;
    private float direction;
    private bool jumpInput;
    private float jumpHoldTime;
    private bool dashInput;
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.PlaySound("Jump");
        jumpHoldTime = playerData.wallJumpHoltTime;
        player.core.Movement.CheckIfShouldFlip(xInput);
        direction = -player.core.Movement.facingDirection;
        player.jumpState.DecreaseAmountOfJumpsLeft();
    }

    public bool CanHoldJump()
    {
        if (Time.time > startTime + jumpHoldTime)
            return false;
        return true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityX(direction * playerData.wallJumpXVelocity);
        core.Movement.SetVelocityY(playerData.jumpVelocity);
    }

    public override void LogicUpdate()
    {
        
        jumpInput = player.inputHandler.jumpInput;
        dashInput = player.inputHandler.dashInput;

        if(dashInput && player.dashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.dashState);
        }
        if (player.inputHandler.attackInputs.primaryAttack && player.CanAttack())
        {
            player.attack.InitiateAttack();
        }

        if (!CanHoldJump() || !jumpInput)
            isAbilityDone = true;
        if (isAbilityDone && jumpInput)
        {
            stateMachine.ChangeState(player.jumpHoldState);
            player.jumpHoldState.ChangeJumpHoldTime(jumpHoldTime);
        }
        else
            base.LogicUpdate();
    }
}
