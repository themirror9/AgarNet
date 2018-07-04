using UnityEngine;

namespace HalfBattery.Events
{
    public class StringEventListener : MonoBehaviour
    {
        public StringEventContainer Events;
        public StringEvent Response ;

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
