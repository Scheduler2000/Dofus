using System.Collections.Generic;
using Medallion.Collections;

namespace Renaissance.Threading.Synchronization.Queue.PriorityQueue
{
    public class SyncPriorityQueue<TEntity, TComparer> where TComparer : IComparer<TEntity>, new()
    {
        public PriorityQueue<TEntity> Data { get; }


        public SyncPriorityQueue() { this.Data = new PriorityQueue<TEntity>(new TComparer()); }

    }
}