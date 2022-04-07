using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceGuildLeavingMessage : Message
{
    public const uint Id = 129;

    public AllianceGuildLeavingMessage(bool kicked, uint guildId)
    {
        Kicked = kicked;
        GuildId = guildId;
    }

    public AllianceGuildLeavingMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Kicked { get; set; }

    public uint GuildId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Kicked);
        writer.WriteVarUInt(GuildId);
    }

    public override void Deserialize(IDataReader reader)
    {
        Kicked = reader.ReadBoolean();
        GuildId = reader.ReadVarUInt();
    }
}