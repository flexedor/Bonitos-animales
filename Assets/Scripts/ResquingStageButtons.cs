using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ResquingStageButtons : MonoBehaviour
{
    public static System.Action MoveCannonLeft, MoveCannonRight, OnShoot, StopCannon;

    public int dir = 0;

    public void onMoveLeft()
    {
        MoveCannonLeft?.Invoke();
    }

    public void leftRelease()
    {
        StopCannon?.Invoke();
    }

    public void onMoveRight()
    {
        MoveCannonRight?.Invoke();
    }

    public void rightRelease()
    {
        StopCannon?.Invoke();
    }
    public void onShoot()
    {
        OnShoot?.Invoke();
    }
}
