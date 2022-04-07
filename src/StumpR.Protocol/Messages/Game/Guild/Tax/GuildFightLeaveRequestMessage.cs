using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFightLeaveRequestMessage : Message
{
    public const uint Id = 5074;

    public GuildFightLeaveRequestMessage(double taxCollectorId, ulong characterId)
    {
        TaxCollectorId = taxCollectorId;
        CharacterId = characterId;
    }

    public GuildFightLeaveRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public double TaxCollectorId { get; set; }

    public ulong CharacterId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(TaxCollectorId);
        writer.WriteVarULong(CharacterId);
    }

    public override void Deserialize(IDataReader reader)
    {
        TaxCollectorId = reader.ReadDouble();
        CharacterId = reader.ReadVarULong();
    }
}