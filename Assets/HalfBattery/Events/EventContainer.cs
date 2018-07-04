using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace HalfBattery.Events
{
    [Serializable]
    public class EventContainer
    {
        public List<EventReference> events = new List<EventReference>();

        public void Raise()
        {
            foreach (var ev in events)
                ev.Raise();
        }

        public void Suscribe(Action callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class EventContainer<T1>
    {
        public List<EventReference<T1>> events = new List<EventReference<T1>>();

        public void Raise(T1 value)
        {
            foreach (var ev in events)
                ev.Raise(value);
        }

        public void Suscribe(Action<T1> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<T1> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class EventContainer<T1, T2>
    {
        public List<EventReference<T1, T2>> events = new List<EventReference<T1, T2>>();

        public void Raise(T1 value1, T2 value2)
        {
            foreach (var ev in events)
                ev.Raise(value1, value2);
        }

        public void Suscribe(Action<T1, T2> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }
        public void Unsuscribe(Action<T1, T2> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class EventContainer<T1, T2, T3>
    {
        public List<EventReference<T1, T2, T3>> events = new List<EventReference<T1, T2, T3>>();

        public void Raise(T1 value1, T2 value2, T3 value3)
        {
            foreach (var ev in events)
                ev.Raise(value1, value2, value3);
        }

        public void Suscribe(Action<T1, T2, T3> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<T1, T2, T3> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class EventContainer<T1, T2, T3, T4>
    {
        public List<EventReference<T1, T2, T3, T4>> events = new List<EventReference<T1, T2, T3, T4>>();

        public void Raise(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            foreach (var ev in events)
                ev.Raise(value1, value2, value3, value4);
        }

        public void Suscribe(Action<T1, T2, T3, T4> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<T1, T2, T3, T4> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

}