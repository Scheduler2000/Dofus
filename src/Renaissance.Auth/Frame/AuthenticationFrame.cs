using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract.Frame;
using Renaissance.Auth.Database.Authentication;
using Renaissance.Auth.IoC;
using Renaissance.Auth.Networking;
using Renaissance.Binary.Definition;
using Renaissance.Protocol;
using Renaissance.Protocol.enums;
using Renaissance.Protocol.messages.common.basic;
using Renaissance.Protocol.messages.connection;
using Renaissance.Protocol.messages.connection.register;
using Renaissance.Protocol.types.connection;

namespace Renaissance.Auth.Frame
{
    public class AuthenticationFrame : IFrame
    {
        [MessageHandler(IdentificationMessage.NetworkId)]
        public void HandleIdentificationMessage(AuthClient client, IDofusMessage message)
        {
            var msg = message as IdentificationMessage;
            Account account = ServiceLocator.Provider.GetService<AccountRepository>()
                .GetEntity(x => x.Login == msg.Username && x.Password == msg.Password);
            if (account == null)
                client.Connection.SendMessageAsync(new IdentificationFailedMessage()
                    .InitIdentificationFailedMessage((byte)IdentificationFailureReasonEnum.WRONG_CREDENTIALS));
            else
            {
                _ = client.Connection.SendMessageAsync(new IdentificationSuccessMessage()
                     .InitIdentificationSuccessMessage("test", "null", 1, 0, new WrappedBool(false), "lol", 12222, 222, 000222
                     , new WrappedBool(false), 0));
                ServersListMessage messa = new ServersListMessage();
                var server = new GameServerInformations()
                             .InitGameServerInformations(new CustomVar<short>(19), (byte)GameServerTypeEnum.SERVER_TYPE_CLASSICAL,new WrappedBool(false), (byte)GameServerTypeEnum.SERVER_TYPE_CLASSICAL,
                             (byte)ServerStatusEnum.ONLINE, new WrappedBool(true), 5, 5, 0) ;

                GameServerInformations[] servers = new GameServerInformations[] { server };
                messa.InitServersListMessage(servers, new CustomVar<short>(0),true);
                client.Connection.SendMessageAsync(messa);
            }
        }

        [MessageHandler(NicknameChoiceRequestMessage.NetworkId)]
        public void HandleNicknameChoiceRequestMessage(AuthClient client, IDofusMessage message)
        {
            var msg = message as NicknameChoiceRequestMessage;
        }

        [MessageHandler(ServerSelectionMessage.NetworkId)]
        public void HandleServerSelectionMessage(AuthClient client, IDofusMessage message)
        {
            var msg = message as ServerSelectionMessage;
        }

        [MessageHandler(BasicPingMessage.NetworkId)]
        public void HandleBasicPingMessage(AuthClient client, IDofusMessage message)
        { client.Connection.SendMessageAsync(new BasicPongMessage()); }
    }
}
