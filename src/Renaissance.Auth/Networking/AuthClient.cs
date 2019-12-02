using Astron.Network.Abstractions;
using Renaissance.Abstract.Network.Framing;
using Renaissance.Abstract.Network.Interface;

namespace Renaissance.Auth.Networking
{
    public class AuthClient : IDofusClient
    {
        public INetworkConnection Connection { get; }


        public AuthClient(INetworkConnection authConnection)
        { this.Connection = authConnection; }
    }
}
