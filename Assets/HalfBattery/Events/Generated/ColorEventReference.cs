using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace HalfBattery.Events
{
    [CreateAssetMenu(menuName = "HalfBattery/Events/Color")]
    public class ColorEventReference : EventReference<Color> { }

    [Serializable]
    public class ColorEventContainer
    {
        public List<ColorEventReference> events = new List<ColorEventReference>();

        public void Raise(Color value1)
        {
            foreach (var ev in events)
                ev.Raise( value1);
        }

        public void Suscribe(Action<Color> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<Color> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class ColorEvent : UnityEvent<Color> { }
}