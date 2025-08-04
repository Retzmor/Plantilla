using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventBus
{
    public static Dictionary<string, List<Delegate>> _eventListener = new();

    public static void Subscribe<T>(string eventName, Action<T> listener)
    {
        if (_eventListener.ContainsKey(eventName))
        {
            _eventListener.Add(eventName, new());
        }
        _eventListener[eventName].Add(listener);
    }   

    public static void Unsubscribe<T>(string eventName, Action<T> listener)
    {
        if( _eventListener.ContainsKey(eventName))
        {
            _eventListener[eventName].Remove(listener);
        }
    }

    public static void Raise(string eventName)
    {

    }
}
