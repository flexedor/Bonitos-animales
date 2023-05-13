using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonScript : MonoBehaviour
{
    private int levelInt = 0;
    public static System.Action<int> onClickLevel;

    public int LevelInt
    {
        get => levelInt;
        set
        {
            levelInt = value;
        }
    }
    public void onClick()
    {
        Debug.Log("Launch resquing nr" + levelInt);
        onClickLevel?.Invoke(levelInt);
    }
}
