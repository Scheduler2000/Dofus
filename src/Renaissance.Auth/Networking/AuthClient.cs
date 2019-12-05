using System;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract.Database.Share;
using Renaissance.Abstract.Network.Interface;
using Renaissance.Auth.IoC;

namespace Renaissance.Auth.Networking
{
    public class AuthClient : IDofusClient
    {
        public INetworkConnection Connection { get; }
       
        public Account Account { get; set; }


        public AuthClient(INetworkConnection authConnection)
        { this.Connection = authConnection; }


        public void Disconnect()
        {
            if (Account != null)
            {
                Account.IsConnected = false;
                ServiceLocator.Provider.GetService<AccountRepository>().Update(Account);
                ServiceLocator.Provider.GetService<AuthServer>().Clients.Remove(this);
            }
        }
    }
}
