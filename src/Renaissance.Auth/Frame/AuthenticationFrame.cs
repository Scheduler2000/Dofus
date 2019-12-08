using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract.Database.Share;
using Renaissance.Abstract.Frame;
using Renaissance.Auth.IoC;
using Renaissance.Auth.Manager;
using Renaissance.Auth.Networking;
using Renaissance.Protocol;
using Renaissance.Protocol.enums;
using Renaissance.Protocol.enums.custom;
using Renaissance.Protocol.messages.common.basic;
using Renaissance.Protocol.messages.connection;
using Renaissance.Protocol.messages.connection.register;
using Renaissance.Protocol.messages.queues;

namespace Renaissance.Auth.Frame
{
    public class AuthenticationFrame : IFrame
    {
        [MessageHandler(IdentificationMessage.NetworkId)]
        public void HandleIdentificationMessage(AuthClient client, IDofusMessage message)
        {
            client.Connection.Send(new LoginQueueStatusMessage().InitLoginQueueStatusMessage(0, 0));

            var msg = message as IdentificationMessage;
            var accountRepository = ServiceLocator.Provider.GetService<AccountRepository>();
            var identificationManager = ServiceLocator.Provider.GetService<IdentificationManager>();
            var authServer = ServiceLocator.Provider.GetService<AuthServer>();

            client.Account = accountRepository
                             .GetEntity(x => x.Login == msg.Username && x.Password == msg.Password);

            if (client.Account == null)
                identificationManager.SendIdentificationFailed(client, IdentificationFailureReasonEnum.WRONG_CREDENTIALS);

            else if (client.Account.IsLifeBanned ||
                    (client.Account.IsBanned && client.Account.BanEndDate > DateTime.Now))
                identificationManager.SendIdentificationFailed(client, IdentificationFailureReasonEnum.BANNED);

            else
            {
                if (client.Account.IsConnected)
                {
                    var alreadyConnected = authServer.Clients.First(x => x.Account.Id == client.Account.Id);
                    alreadyConnected.Dispose();
                }

                client.Account.HardwareId = msg.HardwareId;
                accountRepository.Update(client.Account);

                if (client.Account.Nickname == null)
                    ServiceLocator.Provider.GetService<NicknameManager>().SendNicknameRegistration(client);
                else
                {
                    identificationManager.SendIdentificationSuccess(client);
                    identificationManager.SendServerList(client);
                }
            }
        }

        [MessageHandler(NicknameChoiceRequestMessage.NetworkId)]
        public void HandleNicknameChoiceRequestMessage(AuthClient client, IDofusMessage message)
        {
            var msg = message as NicknameChoiceRequestMessage;
            var nicknameManager = ServiceLocator.Provider.GetService<NicknameManager>();
            var accountRepository = ServiceLocator.Provider.GetService<AccountRepository>();

            if (client.Account.Nickname != null)
                nicknameManager.SendNicknameRefused(client, NicknameErrorEnum.UNKNOWN_NICK_ERROR);

            else if (client.Account.Login == msg.Nickname)
                nicknameManager.SendNicknameRefused(client, NicknameErrorEnum.SAME_AS_LOGIN);

            else if (client.Account.Login.Contains(msg.Nickname) && client.Account.Login.Length - msg.Nickname.Length < 3)
                nicknameManager.SendNicknameRefused(client, NicknameErrorEnum.TOO_SIMILAR_TO_LOGIN);

            else if (accountRepository.GetEntity(x => x.Nickname == msg.Nickname) != null)
                nicknameManager.SendNicknameRefused(client, NicknameErrorEnum.ALREADY_USED);

            else if (msg.Nickname == string.Empty || msg.Nickname.Length >= 15 || msg.Nickname.Contains('\''))
                nicknameManager.SendNicknameRefused(client, NicknameErrorEnum.INVALID_NICK);

            else
            {
                var identificationManager = ServiceLocator.Provider.GetService<IdentificationManager>();

                client.Account.Nickname = msg.Nickname;
                accountRepository.Update(client.Account);

                nicknameManager.SendNicknameAccepted(client);
                identificationManager.SendIdentificationSuccess(client);
                identificationManager.SendServerList(client);
            }
        }

        [MessageHandler(ServerSelectionMessage.NetworkId)]
        public void HandleServerSelectionMessage(AuthClient client, IDofusMessage message)
        {
            var msg = message as ServerSelectionMessage;
            ServiceLocator.Provider.GetService<IdentificationManager>()
                                   .SendSelectedServer(client, msg.ServerId);
        }

        [MessageHandler(BasicPingMessage.NetworkId)]
        public void HandleBasicPingMessage(AuthClient client, IDofusMessage message)
        {
            var msg = message as BasicPingMessage;
            client.Connection.Send(new BasicPongMessage().InitBasicPongMessage(msg.Quiet));
        }
    }
}
