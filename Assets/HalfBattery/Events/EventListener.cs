using System;
using UnityEngine;
using UnityEngine.Events;

namespace HalfBattery.Events
{
    public class EventListener : MonoBehaviour
    {
        public EventContainer Events;
        public UnityEvent Response;

        private void Awake()
        {
            Events.Suscribe(Response.Invoke);
        }

        private void OnDestroy()
        {
            Events.Unsuscribe(Response.Invoke);
        }
    }

    public class EventListener<T1> : MonoBehaviour
    {
        public AuxContainer Events;
        public AuxEvent Response;

        private void Awake()
        {
            Events.Suscribe(Response.Invoke);
        }

        private void OnDestroy()
        {
            Events.Unsuscribe(Response.Invoke);
        }

        public class AuxEvent : UnityEvent <T1> { }
        public class AuxContainer : EventContainer<T1> { }
    }

    public class EventListener<T1, T2> : MonoBehaviour
    {
        public EventContainer<T1, T2> Events;
        public UnityEvent<T1, T2> Response;

        private void Awake()
        {
            Events.Suscribe(Response.Invoke);
        }

        private void OnDestroy()
        {
            Events.Unsuscribe(Response.Invoke);
        }
    }

    public class EventListener<T1, T2, T3> : MonoBehaviour
    {
        public EventContainer<T1, T2, T3> Events;
        public UnityEvent<T1, T2, T3> Response;

        private void Awake()
        {
            Events.Suscribe(Response.Invoke);
        }

        private void OnDestroy()
        {
            Events.Unsuscribe(Response.Invoke);
        }
    }

    public class EventListener<T1, T2, T3, T4> : MonoBehaviour
    {
        public EventContainer<T1, T2, T3, T4> Events;
        public UnityEvent<T1, T2, T3, T4> Response;

        private void Awake()
        {
            Events.Suscribe(Response.Invoke);
        }

        private void OnDestroy()
        {
            Events.Unsuscribe(Response.Invoke);
        }
    }
}