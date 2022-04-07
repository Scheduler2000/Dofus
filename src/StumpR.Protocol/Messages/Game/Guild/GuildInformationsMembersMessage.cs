using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInformationsMembersMessage : Message
{
    public const uint Id = 3627;

    public GuildInformationsMembersMessage(IEnumerable<GuildMember> members)
    {
        Members = members;
    }

    public GuildInformationsMembersMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GuildMember> Members { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Members.Count());
        foreach (GuildMember objectToSend in Members) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort membersCount = reader.ReadUShort();
        var members_ = new GuildMember[membersCount];

        for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
        {
            var objectToAdd = new GuildMember();
            objectToAdd.Deserialize(reader);
            members_[membersIndex] = objectToAdd;
        }
        Members = members_;
    }
}