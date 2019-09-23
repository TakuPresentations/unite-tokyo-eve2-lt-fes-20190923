﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;


public class BrowserAuthorize : MonoBehaviour{
    [SerializeField] private string demoUrl;

    public Action<string, string> OnReceieved = null;

    private void OnApplicationFocus(bool hasFocus)
        {
#if UNITY_ANDROID
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            if (activity == null)
            {
                return;
            }
            AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent");
            if (intent == null){
                return;
            }
            AndroidJavaObject intentUri = intent.Call<AndroidJavaObject>("getData");
            if (intentUri == null)
            {
                return;
            }
            Set<string> paramNames = intentUri.Call<Set<string>>("getQueryParameterNames");
        foreach(string name in paramNames){
        string paramsValue = intentUri.Call<string>("getQueryParameter", name);
        if(!string.IsNullOrEmpty(paramsValue) && OnReceieved != null) OnReceieved(name, paramsValue);
        }
#endif
    }

    public void OpenBrowser()
        {
            
        }
    }