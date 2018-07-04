namespace HalfBattery.Dispatchers
{
    public class OnEnableDispatcher : BehaviourDispatcher
    {
        private void OnEnable()
        {
            RiseEvent();
        }
    } 
}
