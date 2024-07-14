using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PortalAnimation : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        _animator.SetBool("IsOnDistance", IsOnDistance());
    }

    private bool IsOnDistance()
    {
        if (Vector2.Distance(_player.transform.position, transform.position) < 1f)
        {
            return true;
        }
        return false;
    }
}