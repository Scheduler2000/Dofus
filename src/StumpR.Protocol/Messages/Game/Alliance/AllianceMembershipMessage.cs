using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceMembershipMessage : AllianceJoinedMessage
{
    public new const uint Id = 813;

    public AllianceMembershipMessage(AllianceInformations allianceInfo, bool enabled, uint leadingGuildId)
    {
        AllianceInfo = allianceInfo;
        Enabled = enabled;
        LeadingGuildId = leadingGuildId;
    }

    public AllianceMembershipMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}