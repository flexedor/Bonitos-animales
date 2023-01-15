using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuController : MonoBehaviour
{
    public static System.Action onZooBtn;
    public static System.Action onResquingBtn;

    public void onZoo()
    {
        onZooBtn?.Invoke();
    }

    public void onResquing()
    {
        onResquingBtn?.Invoke();
    }
}
