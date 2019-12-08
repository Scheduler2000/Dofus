using System;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract.Database.Share;
using Renaissance.Abstract.Frame;
using Renaissance.Binary.Definition;
using Renaissance.Protocol;
using Renaissance.Protocol.messages.common.basic;
using Renaissance.Protocol.messages.game.approach;
using Renaissance.Protocol.messages.game.basic;
using Renaissance.Protocol.messages.game.character.choice;
using Renaissance.Protocol.messages.secure;
using Renaissance.World.IoC;
using Renaissance.World.Networking;

namespace Renaissance.World.Frame
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
                client.Connection.Send(new AuthenticationTicketRefusedMessage());
            else
            {
                client.Connection.Send(new AuthenticationTicketAcceptedMessage());

                client.Connection.Send(new BasicTimeMessage()
                      .InitBasicTimeMessage((DateTime.Now - new DateTime(1970, 1, 1, 1, 0, 0)).TotalMilliseconds, 60));

                client.Connection.Send(new AccountCapabilitiesMessage()
                      .InitAccountCapabilitiesMessage(client.Account.Id, new WrappedBool(true),
                                                      new CustomVar<int>(262143), new CustomVar<int>(262143),
                                                      0, new WrappedBool(client.Account.CanCreateNewCharacter), 0));

                client.Connection.Send(new TrustStatusMessage()
                      .InitTrustStatusMessage(new WrappedBool(true), new WrappedBool(true)));
            }
        }

        [MessageHandler(CharactersListRequestMessage.NetworkId)]
        public void HandleCharactersListRequestMessage(WorldClient client, IDofusMessage message)
        {
            /*TODO*/
        }

        [MessageHandler(BasicPingMessage.NetworkId)]
        public void HandleBasicPingMessage(WorldClient client, IDofusMessage message)
        {
            var msg = message as BasicPingMessage;
            client.Connection.Send(new BasicPongMessage().InitBasicPongMessage(msg.Quiet));
        }
    }
}
