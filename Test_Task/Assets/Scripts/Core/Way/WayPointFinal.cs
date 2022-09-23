namespace Core
{
    public class WayPointFinal : WayPoint
    {
        public override void ExecuteEvent()
        {
            GameCycle.Finish();
        }
    }
}