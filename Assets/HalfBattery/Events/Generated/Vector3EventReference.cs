using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace HalfBattery.Events
{
    [CreateAssetMenu(menuName = "HalfBattery/Events/Vector3")]
    public class Vector3EventReference : EventReference<Vector3> { }

    [Serializable]
    public class Vector3EventContainer
    {
        public List<Vector3EventReference> events = new List<Vector3EventReference>();

        public void Raise(Vector3 value1)
        {
            foreach (var ev in events)
                ev.Raise( value1);
        }

        public void Suscribe(Action<Vector3> callback)
        {
            foreach (var ev in events)
                ev.Event += callback;
        }

        public void Unsuscribe(Action<Vector3> callback)
        {
            foreach (var ev in events)
                ev.Event -= callback;
        }
    }

    [Serializable]
    public class Vector3Event : UnityEvent<Vector3> { }
}