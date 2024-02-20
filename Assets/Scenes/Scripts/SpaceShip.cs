using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    Vector2 _movement;
    float _horizontal;
    [SerializeField] float _speed = 10f;
    [SerializeField] Shoot _shoot;
    
    //============= Ambas variables sirven para dar un delay entre disparos =============//
    [SerializeField] float _shootRefreshTime = 0.5f;
    float _lastShotTime = 0f;

    void Start()
    {
        gameObject.transform.position = new Vector2(0f, -8f);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoviminetoHorizontal();

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        if (Time.time - _lastShotTime >= _shootRefreshTime)
        {
            _shoot.Spawn(transform.position);
            _lastShotTime = Time.time;
        }
    }

    private void MoviminetoHorizontal()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(_horizontal, 0f);

        if (_horizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (_horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        _rigidbody2D.velocity = Vector2.right * _horizontal * _speed;
    }
}
