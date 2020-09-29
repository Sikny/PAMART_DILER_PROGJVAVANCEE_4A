using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   public CircleCollider2D circleCollider;
   public BaseMovement baseMovement;

   public LayerMask wallLayer;

   private const float Tolerance = 0.1f;


   private void Update()
   {
      RaycastHit2D[] circleCast =
         Physics2D.CircleCastAll(transform.position, circleCollider.radius, Vector2.zero, 0f, wallLayer);

      if (circleCast != null)
      {
         foreach (var raycast in circleCast)
         {
            Vector2 position = transform.position;
            Vector2 contactPoint = raycast.point;
            if (Math.Abs(position.y - contactPoint.y) < Tolerance) {
               baseMovement.XAxis = 0;
            } else if (Math.Abs(position.x - contactPoint.x) < Tolerance) {
               baseMovement.YAxis = 0;
            }
         }
      }
   }
   
}
