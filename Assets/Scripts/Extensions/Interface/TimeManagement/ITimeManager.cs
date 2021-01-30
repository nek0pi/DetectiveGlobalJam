namespace Extensions.Interface.TimeManagement
{
    public interface ITimeManager
    {
        public float timeRemaining { get; set; }
        public bool timeExpired { get; set; }
        public void ChangeTime(float time);
    }
}