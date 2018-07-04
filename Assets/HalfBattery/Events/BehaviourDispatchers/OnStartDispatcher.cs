namespace HalfBattery.Dispatchers
{
    public class OnStartDispatcher : BehaviourDispatcher
    {
        private void Start()
        {
            RiseEvent();
        }
    } 
}
