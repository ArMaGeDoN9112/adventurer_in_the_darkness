

using UnityEngine;

public class IdleState : FsmState
{
    private PatrolEnemy _enemy;
    private float _exitTime;
    private float _timer;

    public IdleState(Fsm fsm, PatrolEnemy enemy, float exitTime) : base(fsm)
    {
        _enemy = enemy;
        _exitTime = exitTime;
    }

    public override void Enter()
    {
        _timer = 0;
    }

    // STEP 4: Сейчас из данного состояния можно перейти только в PatrolState
    // сделайте так, чтобы, при обнаружении игрока, осуществлялся переход в AttackState
    public override void Update(float deltaTime)
    {
        if (_enemy is EnemyWithAttack && ((EnemyWithAttack)_enemy).PlayerInSight())
        {
            Fsm.SetState<AttackState>();
        }

        _timer += Time.deltaTime;

        if (_timer >= _exitTime)
            Fsm.SetState<PatrolState>();
    }
}
