using Renaissance.Threading.Time;

namespace Renaissance.Threading.Callbacking
{
    public interface IExecutable
    {

        ITimerEntry TimerEntry { get; }

        bool Enabled { get; set; }

        bool IsDisposed { get; }

        void Execute();

    }
}
