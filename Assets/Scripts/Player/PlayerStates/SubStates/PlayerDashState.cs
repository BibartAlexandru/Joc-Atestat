using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool canDash { get; private set; }
    private float lastDashTime = -Mathf.Infinity;
    private float gravityScale;
    private float dashDirection;
    private AudioSource audioSource;
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animation,float _gravityScale) : base(_player, _stateMachine, _playerData, _animation)
    {
        gravityScale = _gravityScale;
    }

    public bool CheckIfCanDash()
    {
        return canDash && Time.time >= lastDashTime + playerData.dashCooldown && !core.Movement.stopMovement;
    }

    public override void Enter()
    {
        base.Enter();
        audioSource = player.transform.FindChild("SursaAudio").GetComponent<AudioSource>();
        core.Movement.SetVelocity(0,Vector2.zero,1);
        core.Movement.SetStopMovement(true);
        core.Combat.StartInvincibilityCoRoutine(1f);
        audioSource.PlayOneShot(player.teleportBegin);
        lastDashTime = Time.time;
        player.core.Movement.rigidbody2D.gravityScale = 0f;
        //if(playerData.dashEffect != null)
        //Instantiate(playerData.dashEffect, core.transform.position, Quaternion.Euler(0f,0f, GetRotation()));
        dashDirection = core.Movement.facingDirection;
        player.inputHandler.UseDashInput();//Aveam use jumpinput
        canDash = false;
        //core.Movement.SetVelocityX(playerData.dashVelocity * dashDirection);
    }

    public void Dash()
    {
        if (Physics2D.OverlapCircle((Vector2)player.transform.position + Vector2.right * player.maxDashDistance * dashDirection, player.dashCheckRadius, core.CollisionSenses.WhatIsGround) == null)
            player.transform.Translate(Vector3.right * player.maxDashDistance * dashDirection,Space.World);
        else
        {
            //Debug.Log("SA");
            Vector2 teleportPos = (Vector2)player.transform.position + Vector2.right * player.maxDashDistance * dashDirection;
            while (Physics2D.OverlapCircle(teleportPos, player.dashCheckRadius, core.CollisionSenses.WhatIsGround) != null)
                teleportPos.x += .3f*-dashDirection;
            player.transform.Translate(Mathf.Abs(teleportPos.x-player.transform.position.x)*dashDirection*Vector3.right+Vector3.right*player.dashXOffset*dashDirection, Space.World);
        }
        audioSource.PlayOneShot(player.teleportEnd);
    }

    private float GetRotation()
    {
        if (player.inputHandler.NormalizedInputX == 1 && player.inputHandler.NormalizedInputY == 0)
            return -90f;
        if (player.inputHandler.NormalizedInputX == 1 && player.inputHandler.NormalizedInputY == 1)
            return -45f;
        if (player.inputHandler.NormalizedInputX == 0 && player.inputHandler.NormalizedInputY == 1)
            return 0f;
        if (player.inputHandler.NormalizedInputX == -1 && player.inputHandler.NormalizedInputY == 0)
            return 90f;
        if (player.inputHandler.NormalizedInputX == -1 && player.inputHandler.NormalizedInputY == -1)
            return -225f;
        if (player.inputHandler.NormalizedInputX == -1 && player.inputHandler.NormalizedInputY == 1)
            return 45f;
        if (player.inputHandler.NormalizedInputX == 1 && player.inputHandler.NormalizedInputY == -1)
            return -135f;
        if (player.inputHandler.NormalizedInputX == 0 && player.inputHandler.NormalizedInputY == -1)
            return -180f;
        return 0f;
    }

    public override void Exit()
    {
        base.Exit();
        player.core.Movement.rigidbody2D.gravityScale = gravityScale;
        core.Movement.SetVelocityX(0f);
        core.Movement.SetStopMovement(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > startTime + playerData.dashTime)
            isAbilityDone = true;
    }

    public void ResetCanDash() => canDash = true;

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

}
