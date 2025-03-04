using UnityEngine;


public class DeadState : FsmState
{
    private PatrolEnemy _enemy;
    private Animator _animator;
    private bool _respawn;
    private float _respawnTime;

    public DeadState(Fsm fsm, PatrolEnemy enemy, bool respawn, float respawnTime) : base(fsm)
    {
        _respawn = respawn;
        _respawnTime = respawnTime;
        _animator = enemy.GetComponent<Animator>();
        _enemy = enemy;
    }

    public override void Enter()
    {
        _animator.SetBool("IsDead", true);
    }

    // STEP 11: Если _respawn == true,
    // через _respawnTime секунд мы должны выйти из состояния Dead
    // и восстановить здоровье
    public override void Update(float deltaTime)
    {
        if (_respawn)
        {
            _respawnTime -= Time.fixedDeltaTime;
            if (_respawnTime <= 0)
                Fsm.SetState<PatrolState>();
        }
        return;
    }

    public override void Exit()
    {
        if (_respawn)
        {
            _animator.SetBool("IsDead", false);
            Health health = _enemy.GetComponent<Health>();
            health.Heal(health.MaxHealth);
        }
    }
}
