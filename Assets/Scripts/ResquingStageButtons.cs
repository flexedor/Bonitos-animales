using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResquingStageButtons : MonoBehaviour
{
    public static System.Action MoveCannonLeft, MoveCannonRight, OnShoot;

    public void onMoveLeft()
    {
        MoveCannonLeft?.Invoke();
    }
    public void onMoveRight()
    {
        MoveCannonRight?.Invoke();
    }
    public void onShoot()
    {
        OnShoot?.Invoke();
    }
}
