using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpHoldState : PlayerAbilityState
{
    private bool jumpInput;
    private int xInput;
    private float jumpHoldTime;
    private bool dashInput;
    public PlayerJumpHoldState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public void ChangeJumpHoldTime(float newJumpHoldTime)
    {
        jumpHoldTime = newJumpHoldTime;
    }

    public override void LogicUpdate()
    {
        jumpInput = player.inputHandler.jumpInput;
        xInput = player.inputHandler.NormalizedInputX;
        dashInput = player.inputHandler.dashInput;

        
        if (dashInput && player.dashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.dashState);
            isExitingState = true;
        }
        else if (player.inputHandler.attackInputs.primaryAttack && player.CanAttack())
        {
            player.attack.InitiateAttack();
        }

        if (!CanHoldJump() || !jumpInput)
            isAbilityDone = true;
        if(!isExitingState)
            base.LogicUpdate();
    }

    public bool CanHoldJump()
    {
        if (Time.time > startTime + jumpHoldTime || player.core.CollisionSenses.IsHeadColliding() == true)
        {
            player.inputHandler.UseJumpInput();
            return false;
        }
        return true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.CheckIfShouldFlip(xInput);
        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
        core.Movement.SetVelocityY(playerData.jumpVelocity);

    }

    public override void Enter()
    {
        base.Enter();
        if (player.jumpState.amountOfJumpsLeft == 0)
            jumpHoldTime = playerData.jumpHoldTime / 1.8f;
        else
            jumpHoldTime = playerData.jumpHoldTime;
    }

    public override void Exit()
    {
        base.Exit();
        core.Movement.SetVelocityY(0f);
    }
}
