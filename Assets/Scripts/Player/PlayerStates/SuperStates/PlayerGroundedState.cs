using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    #region Input Variables
    protected int xInput;
    private bool dashInput;
    private bool jumpInput;
    #endregion

    #region Check Variables
    private bool isTouchingWall;
    private bool isGrounded;
    #endregion

    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.core.CollisionSenses.CheckIfGrounded();
        isTouchingWall = player.core.CollisionSenses.CheckIfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();
        player.dashState.ResetCanDash();
        player.jumpState.ResetAmountOfJumpsLeft();
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
            isExitingState = true;
            stateMachine.ChangeState(player.dashState);
        }
        else if(jumpInput && player.jumpState.CanJump())
        {
            isExitingState = true;
            stateMachine.ChangeState(player.jumpState);
        }
        else if (!isGrounded)
        {
            isExitingState = true;
            player.jumpState.DecreaseAmountOfJumpsLeft();
            stateMachine.ChangeState(player.inAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
