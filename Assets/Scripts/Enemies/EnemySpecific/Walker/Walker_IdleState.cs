using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker_IdleState : IdleState
{
    private Walker enemy;
    private AudioSource audioSource;
    public float nextTimeToPlayIdleAudio = 0f;
    public Walker_IdleState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_IdleState _stateData,Walker _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
        audioSource = enemy.transform.gameObject.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        base.Enter();
        //int a = Random.Range(1, 101);
        //if(a <= 20)
           // audioSource.PlayOneShot(enemy.entityData.idle[(int)Random.Range(0,enemy.entityData.idle.Length)]);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        /*
        if (Time.time >= nextTimeToPlayIdleAudio)
        {
            //audioSource.PlayOneShot(enemy.entityData.idle);
            nextTimeToPlayIdleAudio = Time.time + Random.Range(1f,3f);
        }
        */
        base.LogicUpdate();
        if (isPlayerInSmallAgroRange)
        {
            audioSource.PlayOneShot(enemy.entityData.foundPlayer);
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
