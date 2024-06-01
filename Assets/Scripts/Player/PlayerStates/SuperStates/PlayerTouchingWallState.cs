using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected int xInput;
    protected int yInput;
    protected bool jumpInput;
    protected bool dashInput;

    public PlayerTouchingWallState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
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

        player.jumpState.ResetAmountOfJumpsLeft();
        player.dashState.ResetCanDash();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.inputHandler.NormalizedInputX;
        yInput = player.inputHandler.NormalizedInputY;
        jumpInput = player.inputHandler.jumpInput;
        dashInput = player.inputHandler.dashInput;

        if(dashInput && player.dashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.dashState);
        }
        if(jumpInput && player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.wallJumpState);
        }
        if (isGrounded)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if(!isTouchingWall)
        {
            stateMachine.ChangeState(player.inAirState);
        }
    }
}
