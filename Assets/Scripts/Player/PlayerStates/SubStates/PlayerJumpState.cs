using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public int amountOfJumpsLeft { get; private set; }
    private bool jumpInput;
    private bool dashInput;
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.PlaySound("jump");
        isAbilityDone = true;
        if (!isGrounded)
            Instantiate(player.jumpEffect, new Vector2(player.core.CollisionSenses.GroundCheck.position.x, player.core.CollisionSenses.GroundCheck.position.y - 0.3f), Quaternion.identity);
        DecreaseAmountOfJumpsLeft();
        core.Movement.SetVelocityY(playerData.jumpVelocity);
    }

    public void ResetExtraJumps()
    {
        amountOfJumpsLeft = playerData.amountOfJumps - 1;
    }

    public bool CanJump()
    {
        if (amountOfJumpsLeft > 0)
            return true;
        return false;
    }

    public void ResetAmountOfJumpsLeft()
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public void DecreaseAmountOfJumpsLeft()
    {
        amountOfJumpsLeft--;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityY(playerData.jumpVelocity);
    }

    public override void LogicUpdate()  //override la abilitystate
    {
        jumpInput = player.inputHandler.jumpInput;
        dashInput = player.inputHandler.dashInput;


        if (dashInput && player.dashState.CheckIfCanDash())
            stateMachine.ChangeState(player.dashState);
        else if (player.inputHandler.attackInputs.primaryAttack && player.CanAttack())
        {
            player.attack.InitiateAttack();
        }
        else if (isAbilityDone)
        {
            if (isGrounded && core.Movement.currentVelocity.y < 0.01f)
            {
                player.inputHandler.UseJumpInput();
                stateMachine.ChangeState(player.idleState);
            }
            else if (jumpInput)
            {
                stateMachine.ChangeState(player.jumpHoldState);
            }
            else
            {
                player.inputHandler.UseJumpInput();
                stateMachine.ChangeState(player.inAirState);
            }
        }
    }

}
