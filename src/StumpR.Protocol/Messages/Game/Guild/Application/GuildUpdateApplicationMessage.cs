using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildUpdateApplicationMessage : Message
{
    public const uint Id = 6940;

    public GuildUpdateApplicationMessage(string applyText, uint guildId)
    {
        ApplyText = applyText;
        GuildId = guildId;
    }

    public GuildUpdateApplicationMessage()
    {
    }

    public override uint MessageId => Id;

    public string ApplyText { get; set; }

    public uint GuildId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(ApplyText);
        writer.WriteVarUInt(GuildId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ApplyText = reader.ReadUTF();
        GuildId = reader.ReadVarUInt();
    }
}