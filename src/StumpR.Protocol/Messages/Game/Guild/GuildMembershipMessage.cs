using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildMembershipMessage : GuildJoinedMessage
{
    public new const uint Id = 6499;

    public GuildMembershipMessage(GuildInformations guildInfo, uint memberRights)
    {
        GuildInfo = guildInfo;
        MemberRights = memberRights;
    }

    public GuildMembershipMessage()
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