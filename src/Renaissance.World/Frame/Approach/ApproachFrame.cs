using System.Linq;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract.Database.Share;
using Renaissance.Abstract.Frame;
using Renaissance.Protocol;
using Renaissance.Protocol.messages.common.basic;
using Renaissance.Protocol.messages.game.approach;
using Renaissance.World.IoC;
using Renaissance.World.Manager.Frame.Approach;
using Renaissance.World.Networking;

using Stump.DofusProtocol.Enums;

namespace Renaissance.World.Frame.Approach
{
    public class ApproachFrame : IFrame
    {
        [MessageHandler(AuthenticationTicketMessage.NetworkId)]
        public void HandleAuthenticationTicketMessage(WorldClient client, IDofusMessage message)
        {
            var msg = message as AuthenticationTicketMessage;
            string decodedTicket = Encoding.ASCII.GetString(msg.Ticket.Split(',').Select(x => byte.Parse(x)).ToArray());

            client.Account = ServiceLocator.Provider.GetService<AccountRepository>()
                                                    .GetEntity(x => x.Ticket == decodedTicket);

            if (client.Account == null)
            {
                client.Connection.Send(new AuthenticationTicketRefusedMessage());
                client.Dispose();
            }
            else
            {
                var approachManager = ServiceLocator.Provider.GetService<ApproachManager>();

                client.Connection.Send(new AuthenticationTicketAcceptedMessage());

                approachManager.SendServerOptionalFeaturesMessage(client, OptionalFeaturesEnum.PvpArena);
                approachManager.SendServerSessionConstantsMessage(client);
                approachManager.SendAccountCapabilitiesMessage(client);
                approachManager.SendTrustStatusMessage(client);

                client.Account.IsConnected = true;
            }
        }

        [MessageHandler(ReloginTokenRequestMessage.NetworkId)]
        public void HandleReloginTokenRequestMessage(WorldClient client, IDofusMessage message)
        {
            client.Connection.Send(new ReloginTokenStatusMessage()
                             .InitReloginTokenStatusMessage(false,
                              Encoding.ASCII.GetBytes(client.Account.Ticket).Select(x => x).ToArray()));
        }

        [MessageHandler(BasicPingMessage.NetworkId)]
        public void HandleBasicPingMessage(WorldClient client, IDofusMessage message)
        {
            var msg = message as BasicPingMessage;
            client.Connection.Send(new BasicPongMessage().InitBasicPongMessage(msg.Quiet));
        }
    }
}
