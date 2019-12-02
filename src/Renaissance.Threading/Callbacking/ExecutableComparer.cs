using System.Collections.Generic;

namespace Renaissance.Threading.Callbacking
{
    internal class ExecutableComparer : IComparer<IExecutable>
    {
        public int Compare(IExecutable x, IExecutable y)
             => x.TimerEntry.NextTick.CompareTo(y.TimerEntry.NextTick);
    }
}
