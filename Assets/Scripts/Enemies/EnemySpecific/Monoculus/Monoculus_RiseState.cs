using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monoculus_RiseState : MoveState
{
    Monoculus enemy;
    private bool isHeadColliding;
    private bool isGrounded;
    public Monoculus_RiseState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_MoveState _stateData, Monoculus _enemy ) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isHeadColliding = core.CollisionSenses.IsHeadColliding();
        isGrounded = core.CollisionSenses.CheckIfGrounded();
    }

    public override void LogicUpdate()
    {
        DoChecks();
        if (isPlayerInSmallAgroRange)
            stateMachine.ChangeState(enemy.playerDetectedState);
        else if (isHeadColliding || !isGrounded)
            stateMachine.ChangeState(enemy.idleState);
    }
    public override void PhysicsUpdate()
    {
        core.Movement.SetVelocityY(stateData.movementSpeed);
    }
}
