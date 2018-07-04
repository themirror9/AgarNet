namespace HalfBattery.Dispatchers
{
    public class OnAwakeDispatcher : BehaviourDispatcher
    {
        private void Awake()
        {
            RiseEvent();
        }
    } 
}
