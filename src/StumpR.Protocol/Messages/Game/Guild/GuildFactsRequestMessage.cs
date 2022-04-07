using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFactsRequestMessage : Message
{
    public const uint Id = 4628;

    public GuildFactsRequestMessage(uint guildId)
    {
        GuildId = guildId;
    }

    public GuildFactsRequestMessage()
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