using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidNative
{
    private static AndroidJavaObject activityContext;
    private static AndroidJavaClass javaClass;
    private static AndroidJavaObject javaClassInstance;

    public static void SetTest()
    {
        using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            Debug.Log("activityContext :    " + activityContext);
        }

        using (javaClass = new AndroidJavaClass("com.example.gsp_toast.AndroidNative"))
        {
            
            if (javaClass != null)
            {
                
                Debug.Log("JavaClass :    " + javaClass);
                javaClassInstance = javaClass.CallStatic<AndroidJavaObject>("instance");
                Debug.Log("JavaClassInstance :    " + javaClassInstance);
                javaClassInstance.Call("setContext" , activityContext);
            }
        }
    }

    public static void CallShowToast(string text)
    {
        activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            javaClassInstance.Call("ShowToast", text);
        }));
    }
    
}