using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


namespace WebGLSaveExtension
{

    /// <summary>
    /// UnityEngine.PlayerPrefs wrapper for WebGL LocalStorage
    /// </summary>
    public static class WebGLSaveExtension
    {
        public static bool HasKey()
        {
            string key = "SaveData";

            Debug.Log(string.Format("Jammer.PlayerPrefs.HasKey(key: {0})", key));

#if UNITY_WEBGL
            return (HasKeyInLocalStorage(key) == 1);
#else
        return (UnityEngine.PlayerPrefs.HasKey(key: key));
#endif
        }

        public static string GetString(string key)
        {
            Debug.Log((string.Format("Jammer.PlayerPrefs.GetString(key: {0})", key));

#if UNITY_WEBGL
            return LoadFromLocalStorage(key: key);
#else
        return (UnityEngine.PlayerPrefs.GetString(key: key));
#endif
        }

        public static void SetString(string key, string value)
        {
            Debug.Log((string.Format("Jammer.PlayerPrefs.SetString(key: {0}, value: {1})", key, value));

#if UNITY_WEBGL
            SaveToLocalStorage(key: key, value: value);
#else
        UnityEngine.PlayerPrefs.SetString(key: key, value: value);
#endif

        }

        public static void Save()
        {
            Debug.Log(string.Format("Jammer.PlayerPrefs.Save()"));

#if !UNITY_WEBGL
        UnityEngine.PlayerPrefs.Save();
#endif
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern void SaveToLocalStorage(string key, string value);

        [DllImport("__Internal")]
        private static extern string LoadFromLocalStorage(string key);

        [DllImport("__Internal")]
        private static extern void RemoveFromLocalStorage(string key);

        [DllImport("__Internal")]
        private static extern int HasKeyInLocalStorage(string key);
#endif
    }
}