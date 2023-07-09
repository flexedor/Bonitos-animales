using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float borderLim = 1.5f;
    [SerializeField] private float stepOfCannonToMove = 0.1f;
    [SerializeField] private bool isBallStickToCannon=false;
    [SerializeField] private int _numOfBullets;
    private float _positionX;
    private GameObject ball = null;

    public static System.Action<int> OnBallsCountChange;
    public static System.Action OnOutOfBalls;
    public Rigidbody rb;
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
      ResquingStageButtons.StopCannon += StopCannon;
      NumOfBullets = _numOfBullets;
      rb = GetComponent<Rigidbody>();
    }

   private void OnDestroy()
   {
      ResquingStageButtons.OnShoot -= Shoot;
      ResquingStageButtons.MoveCannonLeft -= MoveCannonLeft;
      ResquingStageButtons.MoveCannonRight -= MoveCannonRight;
      ResquingStageButtons.StopCannon -= StopCannon;
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
            ball = Instantiate(BulletPrefab, transform.position + new Vector3(0, 0, -1), Quaternion.identity,
               isBallStickToCannon ? transform : transform.parent);
                ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -3);
         }
      }
   }

   void MoveCannonLeft()
   {
        System.Console.WriteLine("L");
        rb.velocity = new Vector3(-3, 0, 0);
   }

   void MoveCannonRight()
   {
        System.Console.WriteLine("R");
        rb.velocity = new Vector3(3, 0, 0);
   }
   void StopCannon()
   {
        System.Console.WriteLine("STOP");
        rb.velocity = new Vector3(0, 0, 0);
   }
    void SetPosition()
   {
      var position = this.gameObject.transform.position;
      position = new Vector3(PositionX,position.y,position.z);
      this.gameObject.transform.position = position;
   }
}
