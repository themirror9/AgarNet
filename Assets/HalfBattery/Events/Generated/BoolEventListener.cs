using UnityEngine;

namespace HalfBattery.Events
{
    public class BoolEventListener : MonoBehaviour
    {
        public BoolEventContainer Events;
        public BoolEvent Response ;

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
