using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Renaissance.DBSynchroniser.Synchroniser.Pattern;

namespace Renaissance.DBSynchroniser.Synchroniser
{
    public class DatabaseSynchroniser
    {
        private readonly List<ISynchroniser> m_syncs;

        public DatabaseSynchroniser(List<ISynchroniser> syncs)
        { this.m_syncs = syncs; }


        public void Sync()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new List<Task>();

            m_syncs.Where(x => x != null).ToList().ForEach(sync => tasks.Add(new Task(() => sync.Synchronize())));
            tasks.ForEach(task => task.Start());

            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Database Synchronized in {stopwatch.Elapsed.Minutes} minute(s) !");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
