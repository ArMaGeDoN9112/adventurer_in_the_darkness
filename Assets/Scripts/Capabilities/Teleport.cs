using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport _connectedPortal;
    private GameObject _player;
    private PlayerInputHandler _playerInputHandler;


    void Awake()
    {
        _player = GameObject.Find("Player");
        _playerInputHandler = _player.GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        if (_playerInputHandler.HandleUse() && IsOnDistance())
        {
            Invoke(nameof(TeleportPlayer), 0.1f);
        }
    }

    public bool IsOnDistance()
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
