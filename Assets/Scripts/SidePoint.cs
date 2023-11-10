using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePoint : MonoBehaviour
{
   [SerializeField] private Transform _oppositePoing;
   [SerializeField] private Transform _targer;
   [SerializeField] private bool _isLeftSide;

   private void Update()
   {
      if (_isLeftSide)
      {
         if (transform.position.x > _targer.position.x)
         {
            MoveOppositePoint();
         }
         
      }
      else
      {
         if (transform.position.x < _targer.position.x)
         {
            MoveOppositePoint();
         }
      }
   }

   public void MoveOppositePoint()
   {
      _targer.position = new Vector2(_oppositePoing.position.x,_targer.position.y);
   }
}
