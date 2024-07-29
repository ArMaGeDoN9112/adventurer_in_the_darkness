using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport _connectedPortal;
    [SerializeField] private GameObject _player;
    private Animator _animator;
    private PlayerInputHandler _playerInputHandler;
    private Canvas _canvas;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInputHandler = _player.GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        _animator.SetBool("IsOnDistance", IsOnDistance());
        transform.GetChild(0).gameObject.SetActive(IsOnDistance());

        if (_playerInputHandler.HandleUse() && IsOnDistance())
        {
            Invoke(nameof(TeleportPlayer), 0.1f);
        }
    }

    private bool IsOnDistance()
    {
        if (Vector2.Distance(_player.transform.position, transform.position) < 1f)
        {
            return true;
        }
        return false;
    }

    private void TeleportPlayer()
    {
        _player.transform.position = _connectedPortal.transform.position;
    }
}
