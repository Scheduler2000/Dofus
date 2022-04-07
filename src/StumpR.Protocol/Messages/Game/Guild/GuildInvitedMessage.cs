using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInvitedMessage : Message
{
    public const uint Id = 7582;

    public GuildInvitedMessage(ulong recruterId, string recruterName, BasicGuildInformations guildInfo)
    {
        RecruterId = recruterId;
        RecruterName = recruterName;
        GuildInfo = guildInfo;
    }

    public GuildInvitedMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong RecruterId { get; set; }

    public string RecruterName { get; set; }

    public BasicGuildInformations GuildInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(RecruterId);
        writer.WriteUTF(RecruterName);
        GuildInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        RecruterId = reader.ReadVarULong();
        RecruterName = reader.ReadUTF();
        GuildInfo = new BasicGuildInformations();
        GuildInfo.Deserialize(reader);
    }
}