using System;
using UnityEngine;

public class BaseMovement : MonoBehaviour {
    public float speed = 1.0f;
    public float dashDistance = 5f;
    public float dashSpeed = 6f;
    public float maxThrowForce = 30f;
    public float forceDecrease = 10f;
    public float minForce = 15f;

    [HideInInspector] public float offsetFrisbee;
    public CircleCollider2D selfCollider;
    public LayerMask collisionMask;
    
    private bool _isDashing;

    private bool _inDashCooldown;

 
    private int _xAxis;
    private int _yAxis;

    private int _xAxisStartDash;
    private int _yAxisStartDash;
    private bool _lockMove;
    private Frisbee _frisbee;
    private float _throwForce;


    private void Start()
    {
        _throwForce = maxThrowForce;
    }

    private void Update() {
        if (_frisbee)
        {
            Debug.Log("Throw force is : " + _throwForce);
            Debug.Log("decrease is : " + forceDecrease);
            Debug.Log("minForce is : " + minForce);
            //if(_throwForce > minForce)
              //  _throwForce -= forceDecrease * Time.deltaTime;
            return;
            
        }
        if (_isDashing) {
            DoDash();
            if (Vector3.Distance(transform.position, _dashDest) < 0.01f) _isDashing = false;
            return;
        }

        // movement
        Vector2 pos = transform.position;
        Vector2 dest = new Vector2(pos.x + 0.1f * _xAxis, pos.y + 0.1f * _yAxis);
        transform.position = Vector2.MoveTowards(pos, dest, speed * Time.deltaTime);
        
        if (Physics2D.OverlapCircle(transform.position, selfCollider.radius, collisionMask)) {
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
        
        if (Physics2D.OverlapCircle(transform.position, selfCollider.radius, collisionMask)) {
            transform.position = position;
            _isDashing = false;
        }
    }

    public void ThrowFrisbee(int directionHeld) //1 = up, -1 = down, 0 = neutral
    {
        _frisbee.SetIsCaught(false);

        float xDir = _frisbee.transform.position.x - transform.position.x > 0 ? 1 : -1;
        Vector2 direction = new Vector2(xDir, directionHeld);
        
        _frisbee.Move(direction,_throwForce);
        _frisbee = null;
        _throwForce = maxThrowForce;
        _lockMove = false;

    }
    public void LockMove() {
        _lockMove = true;
    }
}