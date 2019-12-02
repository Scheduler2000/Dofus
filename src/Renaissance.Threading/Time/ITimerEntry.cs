using System;

namespace Renaissance.Threading.Time
{
    public interface ITimerEntry
    {
        int Delay { get; set; }

        bool Enabled { get; set; }

        int Interval { get; set; }

        DateTime NextTick { get; }

        void Start();

        void UpdateTimerEntry();
    }
}