using Renaissance.Abstract.Database.Share;

namespace Renaissance.Abstract.Network.Interface
{
    /// <summary>
    /// <see cref="IDofusClient"/> is useful for FrameDispatcher.Dispatch (polymorphism).
    /// </summary>
    public interface IDofusClient
    {
        Account Account { get; set; }
        INetworkConnection Connection { get; }
    }
}
