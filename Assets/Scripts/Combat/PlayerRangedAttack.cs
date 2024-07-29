using UnityEngine;


public class PlayerRangedAttack : AttackBase
{
    [SerializeField] private Projectile _projectilePrefab; // префаб проджектайла
    [SerializeField] private float _projectileSpawnOffset; // отступ, на котором будет спавниться проджектайл
    [SerializeField] private Transform _projectileParent;
    private Vector3[] _directions;
    private int _numberOfProjectiles;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void BeginAttackNew(int numberOfProjectiles)
    {
        if (IsAttacking) return;
        IsAttacking = true;
        _numberOfProjectiles = numberOfProjectiles;
        _directions = new Vector3[numberOfProjectiles];
        GetDirections();

        Invoke(nameof(EndAttackNew), GetAttackAnimationDuration());
        _animator.SetBool("IsAttackingRanged", true);
    }
    private void EndAttackNew()
    {
        base.EndAttack();
        _animator.SetBool("IsAttackingRanged", false);

        // Vector3 direction = new Vector3(transform.localScale.x, 0, 0).normalized;
        foreach (Vector3 direction in _directions)
        {
            int mnoz = direction.y > 0 ? 1 : -1;
            Projectile projectile = Instantiate(
                _projectilePrefab,
                transform.position + direction * _projectileSpawnOffset,
                Quaternion.Euler(mnoz * Vector3.forward * Mathf.Acos(direction.x) * Mathf.Rad2Deg),
                _projectileParent
            );
            // STEP 7: задайте направление движения снаряду
            // projectile.transform.rotation = Quaternion.Euler(Vector3.forward * Mathf.Acos(direction.x) * Mathf.Deg2Rad);
            
            projectile.SetDirection(direction);
        }
    }

    private void GetDirections()
    {
        float angle = 360 / _numberOfProjectiles;
        float step = angle;
        int i = 0;
        while (angle <= 360)
        {
            float angleRad = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleRad);
            float y = Mathf.Sin(angleRad);




            _directions[i] = new Vector3(x * (transform.localScale.x > 0 ? 1 : -1), y, 0);

            i += 1;
            angle += step;
        }
    }
}
