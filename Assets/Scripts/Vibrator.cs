using UnityEngine;

public static  class Vibrator
{
#if UNITY_ANDROID || !UNITY_EDITOR
   private static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
   private static AndroidJavaObject currentActivyty = unityPlayer.GetStatic<AndroidJavaObject>("CurrentActivity");
   private static AndroidJavaObject vibrator = currentActivyty.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
   private static AndroidJavaClass unityPlayer;
    private static AndroidJavaObject currentActivyty;
   private static AndroidJavaObject vibrator;
#endif
   public static void Vibrate(long milliseconds = 250)
   {
      if (IsAndroid())
      {
         vibrator.Call("vibrate", milliseconds);
      }
      else
      {
         Handheld.Vibrate();
      }
   }

   public static void Cancel()
   {
      if (IsAndroid())
      {
         vibrator.Call("cancel");
      }
   }

   private static bool IsAndroid()
   {
      #if UNITY_ANDROID && !UNITY_EDITOR
         return true;
      #else
         return false;
      #endif
   }
}

