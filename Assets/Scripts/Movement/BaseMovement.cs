using UnityEngine;

public class BaseMovement : MonoBehaviour {
    public float speed = 1.0f;
    public float dashDistance = 5f;
    public float dashSpeed = 6f;

    public CircleCollider2D selfCollider;
        
    private bool _isDashing;

    private bool _inDashCooldown;

 
    private int _xAxis;
    private int _yAxis;

    private int _xAxisStartDash;
    private int _yAxisStartDash;
    private bool _lockMove;
    private Frisbee _frisbee;

    private void Update() {
        if (_isDashing) {
            DoDash();
            if (Vector3.Distance(transform.position, _dashDest) < 0.01f) _isDashing = false;
            return;
        }

        // movement
        Vector2 pos = transform.position;
        Vector2 dest = new Vector2(pos.x + 0.1f * _xAxis, pos.y + 0.1f * _yAxis);
        transform.position = Vector2.MoveTowards(pos, dest, speed * Time.deltaTime);
        
        if (Physics2D.OverlapCircle(transform.position, selfCollider.radius, 1 << LayerMask.NameToLayer("Wall"))) {
            transform.position = pos;
        }
    }

    public void SetLateralMove(int direction) {
        _xAxis = _lockMove ? 0 : direction;
    }

    public void SetVerticalMove(int direction) {
        _yAxis = _lockMove ? 0 : direction;
    }


    public Frisbee Frisbee
    {
        get => _frisbee;
        set => _frisbee = value;
    }

   

    private Vector2 _dashDest;
    public void Dash() {
        if (_isDashing) return;

        Vector2 position = transform.position;
        var direction = new Vector2(_xAxis, _yAxis).normalized;
        _dashDest = position + dashDistance * direction;
        _isDashing = true;
    }

    private void DoDash() {
        var position = transform.position;
        //Vector2 dest = new Vector2(position.x + _xAxisStartDash, position.y + _yAxisStartDash);
        transform.position = Vector2.MoveTowards(position, _dashDest, speed * dashSpeed * Time.deltaTime);
        
        if (Physics2D.OverlapCircle(transform.position, selfCollider.radius, 1 << LayerMask.NameToLayer("Wall"))) {
            transform.position = position;
            _isDashing = false;
        }
    }

    public void ThrowFrisbee(int directionHeld) //1 = up, -1 = down, 0 = neutral
    {
        _frisbee.SetIsCaught(false);

        Vector2 direction;
        if(directionHeld == 1)
            direction = new Vector2(1, 1);
        else if(directionHeld == -1)
            direction = new Vector2(1, -1);
        else // 0
            direction = new Vector2(1, 0);
        
        _frisbee.Move(direction,15);
        _frisbee = null;
        _lockMove = false;
        //TODO get direction and throw firsbee at angle

    }
    public void LockMove() {
        _lockMove = true;
    }
}