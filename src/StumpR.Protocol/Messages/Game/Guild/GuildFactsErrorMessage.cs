using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFactsErrorMessage : Message
{
    public const uint Id = 9196;

    public GuildFactsErrorMessage(uint guildId)
    {
        GuildId = guildId;
    }

    public GuildFactsErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public uint GuildId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(GuildId);
    }

    public override void Deserialize(IDataReader reader)
    {
        GuildId = reader.ReadVarUInt();
    }
}