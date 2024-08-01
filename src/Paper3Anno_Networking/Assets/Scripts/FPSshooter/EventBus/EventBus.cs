using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPShooter
{
    public static class EventBus
    {
        //Creazione dizionario
        private static Dictionary<Type, Delegate> _eventTable = new Dictionary<Type, Delegate>();

        public static void Subscribe<T>(Action<T> listener)
        {
            if (_eventTable.TryGetValue(typeof(T), out var d)) {
                _eventTable[typeof(T)] = Delegate.Combine(d, listener);
            }
            else {
                _eventTable[typeof(T)] = listener;
            }
        }

        public static void Unsubscribe<T>(Action<T> listener)
        {
            if (_eventTable.TryGetValue(typeof(T), out var d)) {
                var currentDel = Delegate.Remove(d, listener);

                if (currentDel == null) {
                    _eventTable.Remove(typeof(T));
                }
                else {
                    _eventTable[typeof(T)] = currentDel;
                }
            }
        }

        public static void Publish<T>(T eventArgs)
        {
            if (_eventTable.TryGetValue(typeof(T), out var d)) {
                var callback = d as Action<T>;
                callback?.Invoke(eventArgs);
            }
        }
    }
}
