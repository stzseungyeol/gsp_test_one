using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    
    
public class input_field : MonoBehaviour
{
    public input_field i_f;
    public string toastText;

    public void onValueChanged()
    {
        
        #if UNITY_ANDROID
            showAndroidPopup();
        

        #endif
    }

AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");


    private void showAndroidPopup()
    {
        AndroidJavaClass pop_up = new AndroidJavaClass("android.widget.Toast");
        
        object[] Params = new object[3];
        AndroidJavaClass unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        Params[0] = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");
        Params[1] = toastText;
        Params[2] = toastClass.GetStatic<int>("LENGTH_LONG");


        AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", Params);
        
        toastObject.Call("show");
    }
}
