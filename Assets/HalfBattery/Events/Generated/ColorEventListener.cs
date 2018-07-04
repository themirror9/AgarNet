using UnityEngine;

namespace HalfBattery.Events
{
    public class ColorEventListener : MonoBehaviour
    {
        public ColorEventContainer Events;
        public ColorEvent Response ;

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
