using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsTabloidScript : MonoBehaviour
{
    [SerializeField] private Text tabloidToChange;

    private void Awake()
    {
        CannonScript.OnBallsCountChange += SetText;
    }

    private void OnDestroy()
    {
        CannonScript.OnBallsCountChange -= SetText;
    }

    private void SetText(int num)
    {
        tabloidToChange.text = num.ToString();
    }
}
