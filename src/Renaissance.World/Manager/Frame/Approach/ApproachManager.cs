using System.Collections.Generic;
using System.Linq;
using Renaissance.Abstract.Manager.Interface;
using Renaissance.Binary.Definition;
using Renaissance.Protocol.messages.game.approach;
using Renaissance.Protocol.messages.queues;
using Renaissance.Protocol.messages.secure;
using Renaissance.Protocol.types.game.approach;
using Renaissance.World.Networking;

using Stump.DofusProtocol.Enums;

namespace Renaissance.World.Manager.Frame.Approach
{
    public class ApproachManager : IManager
    {
        private readonly CustomVar<int> m_avaibleBreedsFlags;
        private readonly ServerSessionConstant[] m_sessionsConstants;


        public ApproachManager()
        {
            var avaibleBreeds = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

            this.m_avaibleBreedsFlags =
                new CustomVar<int>(avaibleBreeds.Aggregate(0, (current, breedId) => current | 1 << breedId - 1));

            this.m_sessionsConstants = new ServerSessionConstant[]
            {
                 new ServerSessionConstantInteger()
                        .InitServerSessionConstantInteger(new CustomVar<short>((short)ServerConstantTypeEnum.TIME_BEFORE_DISCONNECTION), 600_000),

                  new ServerSessionConstantInteger()
                        .InitServerSessionConstantInteger(new CustomVar<short>((short)ServerConstantTypeEnum.KOH_DURATION), 7_200_000),

                  new ServerSessionConstantInteger()
                        .InitServerSessionConstantInteger(new CustomVar<short>((short)ServerConstantTypeEnum.KOH_WINNING_SCORE), 30),

                  new ServerSessionConstantInteger()
                        .InitServerSessionConstantInteger(new CustomVar<short>((short)ServerConstantTypeEnum.MINIMAL_TIME_BEFORE_KOH), 86_400_000),

                   new ServerSessionConstantInteger()
                        .InitServerSessionConstantInteger(new CustomVar<short>((short)ServerConstantTypeEnum.TIME_BEFORE_WEIGH_IN_KOH), 600_000),

                   new ServerSessionConstantInteger()
                        .InitServerSessionConstantInteger(new CustomVar<short>((short)ServerConstantTypeEnum.UNKOWN_6), 10),

                   new ServerSessionConstantInteger()
                        .InitServerSessionConstantInteger(new CustomVar<short>((short)ServerConstantTypeEnum.UNKNOW_7), 2_000),

            };
        }

        public void SendServerOptionalFeaturesMessage(WorldClient client, params OptionalFeaturesEnum[] features)
        {
            client.Connection.Send(new ServerOptionalFeaturesMessage()
                             .InitServerOptionalFeaturesMessage(features.Select(x => (byte)x).ToArray()));
        }

        public void SendServerSessionConstantsMessage(WorldClient client)
        {
            client.Connection.Send(new ServerSessionConstantsMessage()
                             .InitServerSessionConstantsMessage(m_sessionsConstants));
        }

        public void SendAccountCapabilitiesMessage(WorldClient client)
        {
            client.Connection.Send(new AccountCapabilitiesMessage()
                             .InitAccountCapabilitiesMessage(client.Account.Id, true,
                                                             m_avaibleBreedsFlags, m_avaibleBreedsFlags,
                                                             (byte)client.Account.Role,
                                                              client.Account.CanCreateNewCharacter, 0));
        }

        public void SendTrustStatusMessage(WorldClient client)
        {
            client.Connection.Send(new TrustStatusMessage()
                      .InitTrustStatusMessage(new WrappedBool(true), new WrappedBool(true)));
        }

        public void SendQueueStatusMessage(WorldClient client, short position, short total)
        {
            client.Connection.Send(new QueueStatusMessage().InitQueueStatusMessage(position, total));
        }

    }
}
