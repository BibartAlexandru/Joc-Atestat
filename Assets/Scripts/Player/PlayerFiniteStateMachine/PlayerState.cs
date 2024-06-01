using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Core core;
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected bool isAnimationFinished;
    public bool isExitingState;
    public bool isExitingSecondaryStage;
    public float startTime { get; private set; }

    public string animation { get; private set; }

    public PlayerState(Player _player, PlayerStateMachine _stateMachine,PlayerData _playerData,string _animation)
    {
        player = _player;
        stateMachine = _stateMachine;
        playerData = _playerData;
        animation = _animation;
        core = player.core; 
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        player.animator.Play(animation);
        isAnimationFinished = false;
        isExitingState = false;
        isExitingSecondaryStage = false;
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

    public virtual void ResetAnimation() => player.animator.Play("EmptyLayer2");

    public virtual void DoChecks()
    {
         
    }
}
