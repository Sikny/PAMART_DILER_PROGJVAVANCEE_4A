using UnityEditor;
using UnityEngine;

namespace Movement {
    public class BaseMovement : MonoBehaviour {
        public Animator animator;
        
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
        private bool _lockThrow;

        private void Start()
        {
            _throwForce = maxThrowForce;
        }

        private void Update() {
            if (_frisbee)
            {
                if(_throwForce > minForce) _throwForce -= forceDecrease * Time.deltaTime;
                return;
            
            }
            if (_isDashing) {
                DoDash();
                if (Vector3.Distance(transform.position, _dashDest) < 0.01f) _isDashing = false;
                return;
            }

            // movement
            Vector2 pos = transform.position;
            Vector2 dir = new Vector2(_xAxis, _yAxis).normalized;
        
            transform.position = GetDestination(pos, dir);
            animator.transform.LookAt(pos + dir, animator.transform.up);

            _currentDashCooldown -= Time.deltaTime;
            if (_currentDashCooldown < 0) _currentDashCooldown = -1f;
        }

        public Vector2 GetDestination(Vector2 position, Vector2 direction, bool isDash = false) {
            Vector2 pos = position;
            float time = 1f / 60f;
            pos += direction.normalized * (time * (isDash ? dashDistance : speed));
            if(Physics2D.OverlapCircle(pos, selfCollider.radius, collisionMask)) pos = position;
            // TODO HANDLE DASH CLOSE TO WALLS
            return pos;
        }

        public void SetMove(Vector2Int direction) {
            _xAxis = _lockMove ? 0 : direction.x;
            _yAxis = _lockMove ? 0 : direction.y;
            if (direction.magnitude > 0.001f && !_lockMove) animator.SetBool("Running", true);
            else animator.SetBool("Running", false);
        }
        
  
        public Frisbee Frisbee
        {
            get => _frisbee;
            set => _frisbee = value;
        }

        private Vector2 _dashDest;

        private float _dashCooldown = 0.2f;
        private float _currentDashCooldown;
        public void Dash(Vector2 direction) {
            if (_isDashing || _lockMove) return;
            if (_currentDashCooldown > 0) return;
            
            GameManager.Instance.soundManager.Play("Dash");
            _currentDashCooldown = _dashCooldown;

            _dashDest = GetDestination(transform.position, direction, true);
            _isDashing = true;
        }

        private void DoDash() {
            var position = transform.position;
        
            transform.position = Vector2.MoveTowards(position, _dashDest, dashSpeed * Time.deltaTime);
        
            if (Physics2D.OverlapCircle(transform.position, selfCollider.radius, collisionMask)) {
                transform.position = position;
                _isDashing = false;
            }
        }

        public void ThrowFrisbee(int directionHeld) //1 = up, -1 = down, 0 = neutral
        {
            if (_lockThrow) return;
            _frisbee.SetIsCaught(false);

            float xDir = _frisbee.transform.position.x - transform.position.x > 0 ? 1 : -1;
            GameManager.Instance.soundManager.Play("Throw");

            Vector2 direction = new Vector2(xDir, directionHeld);
        
            _frisbee.Move(direction,_throwForce);
            _frisbee = null;
            _throwForce = maxThrowForce;
            _lockMove = false;
            GameManager.Instance.isServing = false;
        }
        public void LockMove() {
            _lockMove = true;
        }    
        
        public void UnlockMove() {
            _lockMove = false;
        }
        public void LockThrow() {
            _lockThrow = true;
        }
        
        public void UnlockThrow() {
            _lockThrow = false;
        }
        public void Interact(Vector2Int directionHeld) {
            if(!Frisbee)
                Dash(directionHeld);
            else {
                ThrowFrisbee(directionHeld.y);
            }
        }
    }
}