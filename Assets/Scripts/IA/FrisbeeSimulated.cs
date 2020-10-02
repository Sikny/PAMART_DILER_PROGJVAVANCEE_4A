using System;
using UnityEngine;

namespace IA {
    public class FrisbeeSimulated {
        public Vector2 Position;
        public Vector2 Direction;
        public float Force;
        public float ColliderRadius;
        public bool IsCatched;

        public void UpdateFrisbee() {
            if(!IsCatched)
                MoveDestination();
            HandleWallCollision();
        }

        public void UpdateOffset(float x) {
            Position.x += x;
        }

        private void MoveDestination() {
            float time = 1f / 60f;
            Position += Direction.normalized * (time * Force);
        }

        private void HandleWallCollision() {
            var hit = Physics2D.CircleCast(Position, ColliderRadius, Vector2.zero, 0,
                1 << LayerMask.NameToLayer("Wall"));
            if (hit) {
                Vector2 contactPoint = hit.point;
                float Tolerance = 0.1f;
                if (Math.Abs(Position.y - contactPoint.y) < Tolerance) {
                    Direction.x = -Direction.x;
                } else if (Math.Abs(Position.x - contactPoint.x) < Tolerance) {
                    Direction.y = -Direction.y;
                }
            }
        }

        // 0 : no catch, 1 : player catch, 2 : opponent catch
        public int HandleCollisionWithPlayer(Vector2 selectedActionPosition, Vector2 opponent, float playerRadius) {
            float distanceToPlayer = Vector2.Distance(selectedActionPosition, Position);
            float distanceToOpponent = Vector2.Distance(opponent, Position);
            if (distanceToPlayer <= playerRadius + ColliderRadius) {
                IsCatched = true;
                return 1;
            }
            if (distanceToOpponent <= playerRadius + ColliderRadius) {
                IsCatched = true;
                return 2;
            }
            return 0;
        }
    }
}