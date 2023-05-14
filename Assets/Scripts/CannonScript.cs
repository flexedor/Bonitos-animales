using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float borderLim = 1.5f;
    [SerializeField] private float stepOfCannonToMove = 0.1f;
    [SerializeField] private bool isBallStickToCannon=false;
    private float _positionX;
    private GameObject ball = null;

    public float PositionX
   {
      get => _positionX;
      set {
         if (-borderLim<value && value<borderLim)
         {
            _positionX = value;
         }
      }
   }
   private void Awake()
   {
      _positionX = this.gameObject.transform.position.x;
      ResquingStageButtons.OnShoot += Shoot;
      ResquingStageButtons.MoveCannonLeft += MoveCannonLeft;
      ResquingStageButtons.MoveCannonRight += MoveCannonRight;
   }

   private void OnDestroy()
   {
      ResquingStageButtons.OnShoot -= Shoot;
      ResquingStageButtons.MoveCannonLeft -= MoveCannonLeft;
      ResquingStageButtons.MoveCannonRight -= MoveCannonRight;
   }

   void Shoot()
   {
        if (ball == null)
        {
           ball = Instantiate(BulletPrefab, transform.position, Quaternion.identity, isBallStickToCannon ? transform : transform.parent);
        }
   }

   void MoveCannonLeft()
   {
      PositionX -= stepOfCannonToMove;
      SetPosition();
   }

   void MoveCannonRight()
   {
      PositionX += stepOfCannonToMove;
      SetPosition();
   }

   void SetPosition()
   {
      var position = this.gameObject.transform.position;
      position = new Vector3(PositionX,position.y,position.z);
      this.gameObject.transform.position = position;
   }
}
