using Renaissance.Auth.Networking;
using Renaissance.Protocol.enums.custom;
using Renaissance.Protocol.messages.connection.register;

namespace Renaissance.Auth.Manager
{
    public class NicknameManager
    {
        public void SendNicknameRegistration(AuthClient client)
        { client.Connection.Send(new NicknameRegistrationMessage()); }

        public void SendNicknameRefused(AuthClient client, NicknameErrorEnum reason)
        {
            client.Connection.Send(new NicknameRefusedMessage()
                                 .InitNicknameRefusedMessage((byte)reason));
        }

        public void SendNicknameAccepted(AuthClient client)
        { client.Connection.Send(new NicknameAcceptedMessage()); }

    }
}
