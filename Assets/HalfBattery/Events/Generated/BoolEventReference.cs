using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HalfBattery.Events
{
    [CreateAssetMenu(menuName = "HalfBattery/Events/Bool")]
    public class BoolEventReference : EventReference<bool> { }

    [Serializable]
    public class BoolEventContainer
    {
        public List<BoolEventReference> events = new List<BoolEventReference>();

        public void Raise(bool value)
        {
            foreach (var ev in events)
                ev.Raise(value);
        }

        public void Suscribe(Action<bool> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<bool> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class BoolEvent : UnityEvent<bool> { }
}

