using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport _connectedPortal;
    private GameObject _player;
    private Controller _playerController;


    void Awake()
    {
        _player = GameObject.Find("Player");
        _playerController = _player.GetComponent<Controller>();
    }

    void Update()
    {
        if (_playerController.input.RetrieveUseInput() && IsOnDistance())
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
