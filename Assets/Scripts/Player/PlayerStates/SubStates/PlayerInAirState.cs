using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    #region Input Variables
    private bool jumpInput;
    private int xInput;
    private bool dashInput;
    #endregion

    #region Check Variables
    private bool isGrounded;
    private bool isTouchingWall;
    #endregion

    public PlayerInAirState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.core.CollisionSenses.CheckIfGrounded();
        isTouchingWall = player.core.CollisionSenses.CheckIfTouchingWall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.inputHandler.NormalizedInputX;
        jumpInput = player.inputHandler.jumpInput;
        dashInput = player.inputHandler.dashInput;

        if (player.inputHandler.attackInputs.primaryAttack && player.CanAttack())
        {
            player.attack.InitiateAttack();
        }

        if (dashInput && player.dashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.dashState);
        }
        else if (isGrounded && core.Movement.currentVelocity.y < 0.01f)
        {
            AudioManager.PlaySound("playerStep");
            stateMachine.ChangeState(player.landState);
        }
        else if (jumpInput && player.jumpState.CanJump())
            stateMachine.ChangeState(player.jumpState);
        else if(isTouchingWall && core.Movement.currentVelocity.y <= 0f)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
        else
        {
            player.core.Movement.CheckIfShouldFlip(xInput);
            //core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
    }
}
