using UnityEngine;

namespace HalfBattery.Events
{
    public class Vector3EventListener : MonoBehaviour
    {
        public Vector3EventContainer Events;
        public Vector3Event Response ;

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
