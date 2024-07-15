using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PortalAnimation : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;
    private Teleport _script;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.Find("Player");
        _script = GetComponent<Teleport>();
    }

    private void Update()
    {

        _animator.SetBool("IsOnDistance", _script.IsOnDistance());
    }
}