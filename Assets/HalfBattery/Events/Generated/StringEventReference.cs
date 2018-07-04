using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace HalfBattery.Events
{
    [CreateAssetMenu(menuName = "HalfBattery/Events/String")]
    public class StringEventReference : EventReference<string> { }

    [Serializable]
    public class StringEventContainer
    {
        public List<StringEventReference> events = new List<StringEventReference>();

        public void Raise(string value1)
        {
            foreach (var ev in events)
                ev.Raise( value1);
        }

        public void Suscribe(Action<string> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<string> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class StringEvent : UnityEvent<string> { }
}