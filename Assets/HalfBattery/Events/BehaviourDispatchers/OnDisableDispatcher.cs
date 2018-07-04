namespace HalfBattery.Dispatchers
{
    public class OnDisableDispatcher : BehaviourDispatcher
    {
        private void OnDisable()
        {
            RiseEvent();
        }
    }
}
