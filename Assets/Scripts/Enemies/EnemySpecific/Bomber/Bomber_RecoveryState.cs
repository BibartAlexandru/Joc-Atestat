using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_RecoveryState : RecoveryState
{
    private Bomber enemy;
    private AudioSource audioSource;
    public Bomber_RecoveryState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_RecoveryStateData _stateData,Bomber _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
        audioSource = enemy.transform.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        base.Enter();
        audioSource.PlayOneShot(enemy.sleepSound);
    }

    public override void LogicUpdate()
    {
        if (isRecoveryFinished)
            stateMachine.ChangeState(enemy.playerDetectedState);
    }
}
