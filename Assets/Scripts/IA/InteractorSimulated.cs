using UnityEngine;

namespace IA {
    public class InteractorSimulated {
        public Vector2 Position;
        public bool IsDashing;
        private int _xAxisStartDash;
        private int _yAxisStartDash;
        private bool _lockMove;
        private FrisbeeSimulated _frisbee;

        public FrisbeeSimulated Frisbee {
            get => _frisbee;
            set {
                if (value != null)
                    _lockMove = true;
                _frisbee = value;
            }
        }

        private float _throwForce = 30f;

        public void Interact(Vector2Int directionHeld) {
            if(_frisbee == null)
                Dash(directionHeld);
            else {
                ThrowFrisbee(directionHeld.y);
            }
        }

        private void ThrowFrisbee(int directionHeldY) {
            _frisbee.IsCatched = false;
            
            float xDir = _frisbee.Position.x - Position.x > 0 ? 1 : -1;

            Vector2 direction = new Vector2(xDir, directionHeldY);

            _frisbee.Direction = direction;
            _frisbee.Force = _throwForce;
            _frisbee = null;
            _throwForce = 30f;    // TODO ?
            _lockMove = false;
        }

        private void Dash(Vector2Int directionHeld) {
            // TODO IF SIMULATION WORKS WITHOUT DASH
        }
    }
}
