using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFightJoinRequestMessage : Message
{
    public const uint Id = 9050;

    public GuildFightJoinRequestMessage(double taxCollectorId)
    {
        TaxCollectorId = taxCollectorId;
    }

    public GuildFightJoinRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public double TaxCollectorId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(TaxCollectorId);
    }

    public override void Deserialize(IDataReader reader)
    {
        TaxCollectorId = reader.ReadDouble();
    }
}