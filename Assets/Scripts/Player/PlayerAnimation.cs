using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private AnimationClip _hurtAnimation;
    [SerializeField] public AnimationClip _jumpAnimation;
    private Health _healthComponent;
    private Animator _animator;
    private Rigidbody2D _body;
    private Ground _ground;

    private void OnEnable()
    {
        _healthComponent.OnDamageTaken += EnableHurtParameter;
        _healthComponent.OnDamageTaken += DisableHurtParameter;
        _healthComponent.OnDeath += EnableIsDeadParameter;
    }

    private void OnDisable()
    {
        _healthComponent.OnDamageTaken -= EnableHurtParameter;
        _healthComponent.OnDamageTaken -= DisableHurtParameter;
        _healthComponent.OnDeath -= EnableIsDeadParameter;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
        _healthComponent = GetComponent<Health>();
    }

    private void Update()
    {
        _animator.SetFloat("VelocityX", Mathf.Abs(_body.velocity.x));
        _animator.SetFloat("VelocityY", _body.velocity.y);
    }

    public void SetInputX(float inputX)
    {
        if (inputX == 0) return;
        transform.localScale = new Vector2(
            Mathf.Sign(inputX) * Mathf.Abs(transform.localScale.x),
            transform.localScale.y
        );

    }

    private void EnableIsDeadParameter()
    {
        _animator.SetBool("IsDead", true);
    }

    private void EnableHurtParameter(int damage)
    {
        _animator.SetBool("Hurt", true);
    }

    public void DisableHurtParameter(int damage)
    {
        Invoke(nameof(DisableHurtParameter), _hurtAnimation.length);
    }

    private void DisableHurtParameter()
    {
        _animator.SetBool("Hurt", false);
    }

    public void EnableJumpParameter()
    {
        _animator.SetBool("IsJumping", true);
        Invoke(nameof(DisableJumpParameter), 0.1f);
    }
    private void DisableJumpParameter()
    {
        _animator.SetBool("IsJumping", false);
    }
}