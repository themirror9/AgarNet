using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace HalfBattery.Events
{
    [CreateAssetMenu(menuName = "HalfBattery/Events/Float")]
    public class FloatEventReference : EventReference<float> { }

    [Serializable]
    public class FloatEventContainer
    {
        public List<FloatEventReference> events = new List<FloatEventReference>();

        public void Raise(float value1)
        {
            foreach (var ev in events)
                ev.Raise( value1);
        }

        public void Suscribe(Action<float> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<float> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class FloatEvent : UnityEvent<float> { }
}