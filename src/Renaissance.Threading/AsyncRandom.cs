using System;
using System.Text;
using System.Threading;

namespace Renaissance.Threading
{
    public class AsyncRandom : Random
    {
        private static int m_counter;

        public AsyncRandom() :
            base(Environment.TickCount + Thread.CurrentThread.ManagedThreadId + m_counter)
        { Interlocked.Increment(ref m_counter); }

        public AsyncRandom(int Seed)
            : base(Seed) { }


        public double NextDouble(double min, double max)
        { return (NextDouble() * (max - min)) + min; }

        public string RandomString(int size) /* Useful for ticket account generation */
        {
            var builder = new StringBuilder();

            for (int i = 0; i < size; i++)
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor((26 * NextDouble()) + 65))));

            return builder.ToString();
        }
    }
}
