public class Shooter_IdleState : IdleState
{
    private Shooter enemy;
    public Shooter_IdleState(Entity _entity, FiniteStateMachine _stateMachine, string _animation, D_IdleState _stateData, Shooter _enemy) : base(_entity, _stateMachine, _animation, _stateData)
    {
        enemy = _enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInSmallAgroRange)
        {
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
