using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceChangeGuildRightsMessage : Message
{
    public const uint Id = 8453;

    public AllianceChangeGuildRightsMessage(uint guildId, sbyte rights)
    {
        GuildId = guildId;
        Rights = rights;
    }

    public AllianceChangeGuildRightsMessage()
    {
    }

    public override uint MessageId => Id;

    public uint GuildId { get; set; }

    public sbyte Rights { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(GuildId);
        writer.WriteSByte(Rights);
    }

    public override void Deserialize(IDataReader reader)
    {
        GuildId = reader.ReadVarUInt();
        Rights = reader.ReadSByte();
    }
}