using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _horizontal;
    private IMove _movable;
    private Jump _jump;
    private MeleeAttack _meleeAttack;
    private PlayerRangedAttack _rangedAttack;
    private Health _health;
    private PlayerAnimation _animation;
    private Ground _ground;
    private SetOnPause _pause;
    private CharacterSound _sound;
    private bool _isDead;

    private void OnEnable()
    {
        _health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        _health.OnDeath -= HandleDeath;
    }

    private void Awake()
    {
        _movable = GetComponent<IMove>();
        _jump = GetComponent<Jump>();
        _animation = GetComponent<PlayerAnimation>();
        _meleeAttack = GetComponent<MeleeAttack>();
        _rangedAttack = GetComponent<PlayerRangedAttack>();
        _ground = GetComponent<Ground>();
        _health = GetComponent<Health>();
        _pause = GetComponent<SetOnPause>();
        _sound = GetComponent<CharacterSound>();
    }

    private void Update()
    {
        if (_isDead) return;

        _horizontal = Input.GetAxisRaw("Horizontal");

        _horizontal = (_meleeAttack.IsAttacking || _rangedAttack.IsAttacking) && _ground.OnGround ? 0 : _horizontal;
        _movable.SetVelocity(new Vector2(_horizontal, 0), _speed);
        _animation.SetInputX(_horizontal);


        if (Input.GetButtonDown("Jump"))
        {
            _sound.PlayJumpSound();
            _animation.EnableJumpParameter();
            DoJump();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            _pause.SetPause();
    }

    private void HandleDeath()
    {
        _isDead = true;
    }

    public bool HandleUse()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private void DoJump()
    {
        _jump.Action();
    }
}
