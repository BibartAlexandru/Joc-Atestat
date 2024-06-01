using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation) : base(_player, _stateMachine, _playerData, _animation)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.inputHandler.attackInputs.secondaryAttack == true)
        {
            player.inputHandler.UseSecondaryAttackInput();
            if(player.changeLayerEffect != null)
                GameObject.Instantiate(player.changeLayerEffect, player.transform.position, Quaternion.identity);
            if (player.core.Combat.gameObject.layer == 0)
                player.core.Combat.gameObject.layer = 10;
            else
                player.core.Combat.gameObject.layer = 0;
        }


        if(xInput != 0 && !isExitingState)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
