using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
  [SerializeField] LineRenderer lineRenderer;
    [SerializeField] bool drawPath = true;
      // Start is called before the first frame update
      public enum PathType{
          line,
          loop
      }
      public PathType pathType;
      public int movementDirection=1;
      public int moveTo=0;
      public Transform[] pathElements;
  
      void Start()
      {
        if(drawPath)
        {
          Vector3 voff = new Vector3(0, 0.1f, 0);
          lineRenderer.loop = (pathType == PathType.loop);
          lineRenderer.positionCount = pathElements.Length;
          for(int q = 0; q < pathElements.Length; ++q)
            lineRenderer.SetPosition(q, pathElements[q].position + voff);
        }
      }
  
      public void OnDrawGizmos() {
          if(pathElements==null||pathElements.Length<2)
          {
              return;
          }
          for (int i = 1; i < pathElements.Length; i++)
          {
              Gizmos.DrawLine(pathElements[i-1].position,pathElements[i].position);
          }
          if (pathType == PathType.loop)
          {
              Gizmos.DrawLine(pathElements[0].position,pathElements[pathElements.Length-1].position);
          }
      }
      public Transform GetNextPathPoint(){
          return pathElements[moveTo];
      }
      public void MoveNext(){
           if (pathElements.Length==1)
          {
              //continue;
               return ;
          }
          if (pathType==PathType.line)
          {
              if (moveTo<=0)
              {
                  movementDirection=1;
              }else if(moveTo>=pathElements.Length-1){
                  movementDirection=-1;
              }
  
          }
          moveTo=moveTo+movementDirection;
          if (pathType== PathType.loop)
          {
              if (moveTo>=pathElements.Length)
              {
                  moveTo=0;
              }
              if (moveTo<0)
              {
                  moveTo=pathElements.Length-1;
              }
          }
      }
}
