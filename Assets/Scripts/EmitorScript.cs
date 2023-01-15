using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitorScript : MonoBehaviour
{
   [SerializeField] private GameObject BulletPrefab;
   private float _positionX;
   [SerializeField] private float borderLim = 1.5f;

   public float PositionX
   {
      get
      {
         return _positionX;
      }
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
      Instantiate(BulletPrefab,transform.position, Quaternion.identity, transform);
   }

   void MoveCannonLeft()
   {
      PositionX -= 0.1f;
      SetPosition();
   }

   void MoveCannonRight()
   {
      PositionX += 0.1f;
      SetPosition();
   }

   void SetPosition()
   {
      var position = this.gameObject.transform.position;
      position = new Vector3(PositionX,position.y,position.z);
      this.gameObject.transform.position = position;
   }
}
