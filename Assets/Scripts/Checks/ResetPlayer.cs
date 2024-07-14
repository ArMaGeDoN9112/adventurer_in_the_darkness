using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    private Vector2 _position;
    private Rigidbody2D _body;
    private Vector2 _velocity;

    void Start()
    {
        _position = transform.position;
    }

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        _velocity = _body.velocity;
        if (transform.position.y < -10f)
        {
            _velocity.y = 0f;
            transform.position = _position;
        }
        _body.velocity = _velocity;
    }

}
