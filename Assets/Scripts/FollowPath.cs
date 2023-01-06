using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType 
    {
        Moveng,
        Lerping
    }
    public MovementType Type =MovementType.Moveng;
    public MovementPath MyPaht;
    public float speed =1;
    public float maxDistance=0.1f;
    private Transform pointInPath;

    // Start is called before the first frame update

    void Start()
    {
        if (MyPaht==null)
        {
            Debug.Log("no Path");
            return;
        }
        pointInPath = MyPaht.GetNextPathPoint();
        MyPaht.MoveNext();
        if (pointInPath==null)
        {
            Debug.Log("need Points");
            return;
        }
        transform.position=pointInPath.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointInPath==null || pointInPath==null)
        {
            return;
        }
        pointInPath = MyPaht.GetNextPathPoint();
        if(Type==MovementType.Moveng)
        {
            transform.position=Vector3.MoveTowards(transform.position,pointInPath.position,Time.deltaTime*speed);
        }else if (Type==MovementType.Lerping){
            transform.position=Vector3.Lerp(transform.position,pointInPath.position,Time.deltaTime*speed);

        }
        var distanceSquer=(transform.position-pointInPath.position).sqrMagnitude;
        if (distanceSquer<maxDistance*maxDistance*maxDistance)
        {
            MyPaht.MoveNext();
        }
    }
}
