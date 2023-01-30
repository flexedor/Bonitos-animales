using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationController : MonoBehaviour
{
    public void Vibrate(long milliseconds)
    {
        if (milliseconds<100 )return;
        
        Vibrator.Vibrate(milliseconds);
    }

    public void VibrateDefault()
    {
        
        Vibrator.Vibrate();
    }

    public static void VibrateLow()
    {
        Vibrator.Vibrate(200);
    }
    public static void VibrateMid()
    {
        Vibrator.Vibrate(500);
    }
    public static void VibrateHigh()
    {
        Vibrator.Vibrate(750);
    }

    public static void Cancel()
    {
        Vibrator.Cancel();
    }
}
