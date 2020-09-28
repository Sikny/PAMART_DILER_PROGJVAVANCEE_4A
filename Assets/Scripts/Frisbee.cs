using UnityEngine;

public class Frisbee : MonoBehaviour {
    private Vector2 _direction;
    private float _force;
    
    private void Update() {
        Vector3 pos = transform.position;
        Vector3 dest = pos;
        dest.x += _direction.x;
        dest.z += _direction.y;
        transform.position = Vector3.MoveTowards(pos, dest, _force * Time.deltaTime);
    }

    public void Move(Vector2 direction, float force) {
        _direction = direction.normalized;
        _force = force;
    }
}
