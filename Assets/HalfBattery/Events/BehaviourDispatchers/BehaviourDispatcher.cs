using UnityEngine;
using System;
using UnityEngine.Events;

namespace HalfBattery.Dispatchers
{
    public abstract class BehaviourDispatcher : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent unityEvent;
        protected event Action OnEvent = delegate { };

        protected void RiseEvent()
        {
            if (unityEvent != null) unityEvent.Invoke();
            OnEvent();
        }

        public void Subscribe(Action action)
        {
            OnEvent += action;
        }

        public void Unsubscribe(Action action)
        {
            OnEvent -= action;
        }
    }

}