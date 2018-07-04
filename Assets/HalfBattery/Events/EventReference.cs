using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HalfBattery.Events
{
    [CreateAssetMenu(menuName = "HalfBattery/Events/No Parameters", order = -100)]
    public class EventReference : ScriptableObject
    {
        public event Action Event = delegate { };

        [Multiline]
        public string description;

        public void Raise()
        {
            Event();
        }
    }

    public class EventReference<T> : ScriptableObject
    {
        public event Action<T> Event = delegate { };

#if UNITY_EDITOR
        [Multiline]
        public string description;
#endif

        public void Raise(T value)
        {
            Event(value);
        }
    }

    public class EventReference<T1, T2> : ScriptableObject
    {
        public event Action<T1, T2> Event = delegate { };

        [Multiline]
        public string description;

        public void Raise(T1 value1, T2 value2)
        {
            Event(value1, value2);
        }
    }

    public class EventReference<T1, T2, T3> : ScriptableObject
    {
        public event Action<T1, T2, T3> Event = delegate { };

        [Multiline]
        public string description;

        public void Raise(T1 value1, T2 value2, T3 value3)
        {
            Event(value1, value2, value3);
        }
    }

    public class EventReference<T1, T2, T3, T4> : ScriptableObject
    {
        public event Action<T1, T2, T3, T4> Event = delegate { };

        [Multiline]
        public string description;

        public void Raise(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Event(value1, value2, value3, value4);
        }
    }
}
