using System;
using System.Collections.Generic;
using System.Text;

namespace Renaissance.Abstract.Network.Interface
{
    /// <summary>
    /// <see cref="IDofusClient"/> is useful for FrameDispatcher.Dispatch (polymorphism).
    /// </summary>
    public interface IDofusClient
    {
        INetworkConnection Connection { get; }
    }
}
