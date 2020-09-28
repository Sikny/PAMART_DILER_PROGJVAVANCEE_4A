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
}
