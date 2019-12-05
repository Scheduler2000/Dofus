using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Renaissance.Threading.Callbacking;
using Renaissance.Threading.Synchronization.List;
using Renaissance.Threading.Synchronization.Queue.LockFree;
using Renaissance.Threading.Synchronization.Queue.PriorityQueue;

namespace Renaissance.Threading
{
    /// <summary>
    /// <see cref="AsyncPool"/> represents a set of instructions to be performed by one <see cref="Thread"/> 
    /// at a time and allows <see cref="Instruction"/> to be dispatched.
    /// </summary>
    /// <remarks>Thank's to WCell Project for this great idea and Stump.</remarks>
    public class AsyncPool : IContextHandler
    {
        private readonly LockFreeQueue<IExecutable> m_executableQueue; /* For waited single instruction and single instruction. */
        private readonly SyncPriorityQueue<IExecutable, ExecutableComparer> m_executablePQueue; /* Only for delayed and periodical instruction */
        private readonly SyncList<IExecutable> m_pausedExecutable; /*Only for paused instruction.*/
        private readonly Stopwatch m_stopwatch = new Stopwatch();
        private readonly int m_updateInterval;
        private readonly string m_name;
        private int m_currentThreadId;
        private Task m_worker;

        public bool IsInContext { get => Thread.CurrentThread.ManagedThreadId == m_currentThreadId; }


        public AsyncPool(int interval, string name)
        {
            this.m_executableQueue = new LockFreeQueue<IExecutable>();
            this.m_executablePQueue = new SyncPriorityQueue<IExecutable, ExecutableComparer>();
            this.m_pausedExecutable = new SyncList<IExecutable>();
            this.m_stopwatch.Start();
            this.m_updateInterval = interval;
            this.m_name = name;

        }


        public void Start()
            => this.m_worker = Task.Factory.StartNewDelayed(m_updateInterval, ProcessThreadPool, this);

        public IExecutable ExecuteDelayed(Action method, int delayMillis)
        {
            Instruction instruction = new Instruction(method, delayMillis, default);
            AddTimedExecutable(instruction);
            return instruction;
        }

        public IExecutable ExecutePeriodically(Action method, int delayMillis)
        {
            Instruction instruction = new Instruction(method, delayMillis);
            AddTimedExecutable(instruction);
            return instruction;
        }

        public void ExecuteInContext(Action action)
        {
            if (IsInContext)
                action?.Invoke();
            else
                m_executableQueue.Enqueue(new Instruction(action));
        }

        public void RemoveExecutable(IExecutable executable)
            => ExecuteInContext(() => m_executablePQueue.Data.Remove(executable));

        private void AddTimedExecutable(IExecutable executable)
        {
            ExecuteInContext(() =>
            {
                if (!executable.TimerEntry.Enabled)
                    executable.TimerEntry.Start();
                m_executablePQueue.Data.Enqueue(executable);
            });
        }

        private void ProcessThreadPool(object state)
        {
            if (Interlocked.CompareExchange(ref m_currentThreadId, Thread.CurrentThread.ManagedThreadId, 0) != 0)
                return;

            long timerStart = m_stopwatch.ElapsedMilliseconds;

            try
            {
                while (m_executableQueue.TryDequeue(out IExecutable executable)) /* Process single executable.*/
                    executable.Execute();

                foreach (var exe in m_pausedExecutable.Where(x => x.Enabled)) /* Update executable reactivated.*/
                    m_executablePQueue.Data.Enqueue(exe);

                IExecutable smallest;
                while (m_executablePQueue.Data.Count > 0 && m_executablePQueue.Data.Peek().TimerEntry.NextTick <= DateTime.Now)
                {
                    smallest = m_executablePQueue.Data.Dequeue();
                    if (!smallest.TimerEntry.Enabled && !smallest.IsDisposed)
                        m_pausedExecutable.Add(smallest);
                    else
                    {
                        smallest.Execute();
                        if (!smallest.IsDisposed)
                            m_executablePQueue.Data.Enqueue(smallest);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{DateTime.Now}] [Error] Exception at Thread Pool <{m_name}> : {ex.ToString()}");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            finally
            {
                long timerStop = m_stopwatch.ElapsedMilliseconds;
                bool updateLagged = timerStop - timerStart > m_updateInterval ? true : false;
                long callbackTimeout = updateLagged ? 0 : timerStart + m_updateInterval - timerStop;

                Interlocked.Exchange(ref m_currentThreadId, 0);
                m_worker = Task.Factory.StartNewDelayed((int)callbackTimeout, ProcessThreadPool, this);
            }
        }
    }
}