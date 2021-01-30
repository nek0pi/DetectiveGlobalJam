using System;
using Extensions.Interface.TimeManagement;

namespace TimeManager
{
    public class TimeManager : ITimeManager
    {
        public float timeRemaining { get; set; }
        public bool timeExpired { get; set; }
        
        public void ChangeTime(float time)
        {
            timeRemaining -= time;
            timeRemaining = Math.Max(0, timeRemaining);
            if (timeRemaining == 0)
            {
                timeExpired = true;
            }
        }
    }
}