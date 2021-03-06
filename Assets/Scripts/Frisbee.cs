﻿using System;
using UnityEngine;

public class Frisbee : MonoBehaviour
{

    public float offsetToPlayer = 3f;
    private Vector2 _direction;
    private float _force;
    private bool _isCaught;
    private Transform _playerPosition;
    public CircleCollider2D circleCollider;
    public Vector2 Direction => _direction;
    public float Force => _force;

    private void Update() {
        if (_isCaught)
        {
            SetPosition();
            _isCaught = false;
            return;
        }
        Vector2 pos = transform.position;
        Vector2 dest = pos;
        dest += _direction;
        
        transform.position = Vector2.MoveTowards(pos, dest, _force * Time.deltaTime);
        //transform.position = GetDestination(pos, _direction);
        if (Input.GetKeyDown(KeyCode.A)) {
            Move(new Vector2(1, 1), 15);
        }
     
    }
    
    /*public Vector2 GetDestination(Vector2 position, Vector2 direction) {
        Vector2 pos = position;
        float time = 1f / 60f;
        direction.y = 0;
        pos += direction.normalized * (time * _force);
        return pos;
    }*/

    public void Move(Vector2 direction, float force) {
        _direction = direction.normalized;
        _force = force;
    }

    
    public void SetIsCaught(bool isCaught) {
        _isCaught = isCaught;
    }

    public void SetPlayerPos(Transform playerPosition)
    {
        _playerPosition = playerPosition;
    }

    public void SetPosition()
    {
        _isCaught = false;

        Vector2 newPosition = new Vector2(_playerPosition.position.x + offsetToPlayer, _playerPosition.position.y);
        
        transform.position = newPosition;

        Move(newPosition, 0);
    }
    private const float Tolerance = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall")) {
            Vector2 position = transform.position;
            Vector2 contactPoint = collision.contacts[0].point;
            if (Math.Abs(position.y - contactPoint.y) < Tolerance) {
                _direction.x = -_direction.x;
            } else if (Math.Abs(position.x - contactPoint.x) < Tolerance) {
                _direction.y = -_direction.y;
            }
        }
    }
}
