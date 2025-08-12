using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventBus
{
    public static Dictionary<string, List<Delegate>> _eventListener = new();

    public static void Subscribe<T>(string eventName, Action<T> listener)
    {
        if (!_eventListener.ContainsKey(eventName))
        {
            _eventListener.Add(eventName, new List<Delegate>());
        }
        _eventListener[eventName].Add(listener);
    }

    public static void Subscribe(string eventName, Action listener)
    {
        if (!_eventListener.ContainsKey(eventName))
        {
            _eventListener.Add(eventName, new List<Delegate>());
        }
        _eventListener[eventName].Add(listener);
    }

    public static void Unsubscribe<T>(string eventName, Action<T> listener)
    {
        if(_eventListener.ContainsKey(eventName))
        {
            _eventListener[eventName].Remove(listener);
        }
    }

    public static void Unsubscribe(string eventName, Action listener)
    {
        if (_eventListener.ContainsKey(eventName))
        {
            _eventListener[eventName].Remove(listener);
        }
    }

    public static void InvokeEvent<T>(string eventName, T EventData)
    {
        if (_eventListener.ContainsKey(eventName))
        {
            foreach (var listener in _eventListener[eventName]) 
            {
                ((Action<T>)listener).Invoke(EventData);
            }
        }
    }

    public static void InvokeEvent(string eventName)
    {
        if (_eventListener.ContainsKey(eventName))
        {
            foreach (var listener in _eventListener[eventName])
            {
                ((Action)listener).Invoke();
            }
        }
    }
}
