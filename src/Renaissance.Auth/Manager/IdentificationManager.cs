using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract.Database.Share;
using Renaissance.Auth.IoC;
using Renaissance.Auth.Networking;
using Renaissance.Binary.Definition;
using Renaissance.Protocol.enums;
using Renaissance.Protocol.messages.connection;
using Renaissance.Protocol.types.connection;
using Renaissance.Threading;

namespace Renaissance.Auth.Manager
{
    public class IdentificationManager
    {

        public void SendIdentificationFailed(AuthClient client, IdentificationFailureReasonEnum reason)
        {
            client.Connection.Send(new IdentificationFailedMessage()
                             .InitIdentificationFailedMessage((byte)reason));
        }

        public void SendIdentificationSuccess(AuthClient client)
        {
            client.Account.IsConnected = true;
            ServiceLocator.Provider.GetService<AccountRepository>().Update(client.Account);
            ServiceLocator.Provider.GetService<AuthServer>().Clients.Add(client);

            client.Connection.Send(new IdentificationSuccessMessage()
                             .InitIdentificationSuccessMessage(client.Account.Login, client.Account.Nickname,
                                                               client.Account.Id, 0, new WrappedBool(client.Account.IsAdmin),
                                                               client.Account.SecretQuestion, 0, 0, 0,
                                                               new WrappedBool(false), 1));
        }

        public void SendServerList(AuthClient client)
        {
            var servers = new GameServerInformations[]
            {
                 new GameServerInformations()
                             .InitGameServerInformations(new CustomVar<short>(20),
                             (byte)GameServerTypeEnum.SERVER_TYPE_CLASSICAL,new WrappedBool(false),
                             (byte)ServerStatusEnum.ONLINE,(byte)ServerCompletionEnum.COMPLETION_RECOMANDATED,
                             new WrappedBool(true),5, 5, 0)
            };

            client.Connection.Send(new ServersListMessage()
                .InitServersListMessage(servers, new CustomVar<short>(0),
                                        client.Account.CanCreateNewCharacter));
        }

        public void SendSelectedServer(AuthClient client, CustomVar<short> serverId)
        {
            client.Account.Ticket = new AsyncRandom().RandomString(32);
            ServiceLocator.Provider.GetService<AccountRepository>().Update(client.Account);

            client.Connection.Send(new SelectedServerDataMessage()
                             .InitSelectedServerDataMessage(serverId, "127.0.0.1",
                                                            new int[] { 5555 }, client.Account.CanCreateNewCharacter,
                                                            Encoding.ASCII.GetBytes(client.Account.Ticket)));
            client.Dispose();
        }
    }
}
