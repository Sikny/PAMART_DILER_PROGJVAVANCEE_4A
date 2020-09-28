using System;
using UnityEngine;

public class Frisbee : MonoBehaviour {
    private Vector2 _direction;
    private float _force;
    
    private void Update() {
        Vector2 pos = transform.position;
        Vector2 dest = pos;
        dest += _direction;
        transform.position = Vector2.MoveTowards(pos, dest, _force * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.A)) {
            Move(new Vector2(1, 1), 15);
        }
    }

    public void Move(Vector2 direction, float force) {
        _direction = direction.normalized;
        _force = force;
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
