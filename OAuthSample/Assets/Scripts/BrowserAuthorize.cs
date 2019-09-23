using UnityEngine;
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
            string[] paramNames = intentUri.Call<string[]>("getQueryParameterNames");
            Debug.Log(paramNames);

            foreach (string paramName in paramNames){
                string paramsValue = intentUri.Call<string>("getQueryParameter", paramName);
                if(!string.IsNullOrEmpty(paramsValue) && OnReceieved != null) OnReceieved(paramName, paramsValue);
            }
#endif
    }

    public void OnOpenUrl(string url)
    {
        string authCode = "";
        string[] pathQuery = url.Split('?');
        if (pathQuery.Length > 1)
        {
            string[] urlQueryPairs = pathQuery[pathQuery.Length - 1].Split('&');
            for (int i = 0; i < urlQueryPairs.Length; ++i)
            {
                string[] keyValue = urlQueryPairs[i].Split('=');
                if (keyValue.Length > 1)
                {
                    if (!string.IsNullOrEmpty(keyValue[0]) && OnReceieved != null) OnReceieved(keyValue[0], keyValue[1]);
                }
            }
        }
    }
}
