using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInformationsMemberUpdateMessage : Message
{
    public const uint Id = 6301;

    public GuildInformationsMemberUpdateMessage(GuildMember member)
    {
        Member = member;
    }

    public GuildInformationsMemberUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public GuildMember Member { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Member.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Member = new GuildMember();
        Member.Deserialize(reader);
    }
}