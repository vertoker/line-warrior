using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace Game.SceneStaticMemory
{
    public static class SceneStaticMemory
    {
        private static Dictionary<string, object> _parameters = new Dictionary<string, object>();

        public static void AddValue<T>(string key, T value)
        {
            _parameters.Add(key, value);
        }
        public static void RemoveValue<T>(string key)
        {
            _parameters.Remove(key);
        }
        public static T GetValue<T>(string key)
        {
            return (T)_parameters[key];
        }
        public static void SetValue<T>(string key, T value)
        {
            _parameters[key] = value;
        }
    }
}