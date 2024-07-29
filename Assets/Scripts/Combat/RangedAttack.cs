using UnityEngine;


public class RangedAttack : AttackBase
{
    [SerializeField] private Projectile _projectilePrefab; // префаб проджектайла
    [SerializeField] private float _projectileSpawnOffset; // отступ, на котором будет спавниться проджектайл
    [SerializeField] private Transform _projectileParent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void BeginAttack()
    {
        if (IsAttacking) return;
        base.BeginAttack();
        _animator.SetBool("IsAttackingRanged", true);
    }

    public override void EndAttack()
    {
        base.EndAttack();
        _animator.SetBool("IsAttackingRanged", false);

        Vector3 toTarget = (_target - transform.position).normalized;
        int mnoz = toTarget.y > 0 ? 1 : -1;
        Projectile projectile = Instantiate(
            _projectilePrefab,
            transform.position + toTarget * _projectileSpawnOffset,
            Quaternion.Euler(mnoz * Vector3.forward * Mathf.Acos(toTarget.x) * Mathf.Rad2Deg),
            _projectileParent
        );

        // STEP 7: задайте направление движения снаряду
        projectile.SetDirection(toTarget);
    }
}