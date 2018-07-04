namespace HalfBattery.Dispatchers
{
    public class OnDestroyDispatcher : BehaviourDispatcher
    {
        private void OnDestroy()
        {
            RiseEvent();
        }
    } 
}
