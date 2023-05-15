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
     private int _numOfBullets=0;
    private float _positionX;
    private GameObject ball = null;

    public static System.Action<int> OnBallsCountChange;
    public static System.Action OnOutOfBalls;

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

    public int NumOfBullets
    {
       get => _numOfBullets;
       set
       {
          if (value>=0)
          {
             _numOfBullets = value;
             OnBallsCountChange?.Invoke(_numOfBullets);
          }
          else
          {
             OnOutOfBalls?.Invoke();
          }
       }
    }
   private void Awake()
   {
      _positionX = this.gameObject.transform.position.x;
      ResquingStageButtons.OnShoot += Shoot;
      ResquingStageButtons.MoveCannonLeft += MoveCannonLeft;
      ResquingStageButtons.MoveCannonRight += MoveCannonRight;
      NumOfBullets = 3;
   }

   private void OnDestroy()
   {
      ResquingStageButtons.OnShoot -= Shoot;
      ResquingStageButtons.MoveCannonLeft -= MoveCannonLeft;
      ResquingStageButtons.MoveCannonRight -= MoveCannonRight;
   }

   void Shoot()
   {
      if (_numOfBullets==0)
      {
         OnOutOfBalls?.Invoke();
      }
      else
      {
         if (ball == null)
         {
            NumOfBullets--;
            ball = Instantiate(BulletPrefab, transform.position, Quaternion.identity,
               isBallStickToCannon ? transform : transform.parent);
         }
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
