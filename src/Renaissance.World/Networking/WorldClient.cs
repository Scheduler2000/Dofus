using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract.Database.Share;
using Renaissance.Abstract.Network.Interface;
using Renaissance.World.Database.Characters;
using Renaissance.World.Game.Actors.Characters;
using Renaissance.World.IoC;

namespace Renaissance.World.Networking
{
    public class WorldClient : IDofusClient
    {
        public INetworkConnection Connection { get; }

        public Account Account { get; set; }

        public Character Character { get; set; }


        public WorldClient(INetworkConnection authConnection)
        { this.Connection = authConnection; }


        public void OnDisconnected()
        {
            if (Account != null)
            {
                Account.IsConnected = false;
                ServiceLocator.Provider.GetService<AccountRepository>().Update(Account);
                ServiceLocator.Provider.GetService<WorldServer>().Clients.Remove(this);
            }
        }

        public void Dispose()
        { Connection.Close(); }
    }
}
