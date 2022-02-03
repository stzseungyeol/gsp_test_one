using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text asd;

    private void Awake()
    {
        try
        {
            AndroidNative.SetTest();
        }
        catch (Exception e)
        {
            asd.text += e;
            
        }
    }

    public void OnToast(InputField text)
    {
        try
        {
            AndroidNative.CallShowToast(text.textComponent.text);
        }
        catch (Exception e)
        {
            asd.text += "\n" + e;
        }

        asd.text += "\n" + text.textComponent.text;
        Debug.Log(text.textComponent.text);
    }
    
}