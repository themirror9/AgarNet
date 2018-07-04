using UnityEngine;

namespace HalfBattery.Events
{
    public class FloatEventListener : MonoBehaviour
    {
        public FloatEventContainer Events;
        public FloatEvent Response ;

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
