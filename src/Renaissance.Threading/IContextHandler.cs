﻿using System;
using System.Threading;
using Renaissance.Threading.Callbacking;

namespace Atarax.Threading
{
    /// <summary>
    /// <see cref="IContextHandler"/> represents a set of instructions to be performed by one <see cref="Thread"/> 
    /// at a time and allows <see cref="Instruction"/> to be dispatched.
    /// </summary>
    /// <remarks>Thank's to WCell Project for this great idea and Stump.</remarks>
    public interface IContextHandler
    {
        bool IsInContext { get; }

        void Start();

        IExecutable ExecutePeriodically(Action method, int delayMillis);

        IExecutable ExecuteDelayed(Action method, int delayMillis);

        /// <summary>
        /// Executes action instantly, if in context.
        /// Enqueues a Message to execute it later, if not in context.
        /// </summary>
        void ExecuteInContext(Action action);

    }
}
