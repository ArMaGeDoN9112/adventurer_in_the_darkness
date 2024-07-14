using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body;
    private Ground _ground;
    private Controller _controller;
    private float _horizontalInput;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
    }

    private void Update()
    {
        _animator.SetFloat("VelocityX", Mathf.Abs(_body.velocity.x));
        _animator.SetBool("IsJumping", !_ground.OnGround);
        _animator.SetFloat("VelocityY", _body.velocity.y);
    }
}