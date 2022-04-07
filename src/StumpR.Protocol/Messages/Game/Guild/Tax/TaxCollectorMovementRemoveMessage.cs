using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorMovementRemoveMessage : Message
{
    public const uint Id = 5927;

    public TaxCollectorMovementRemoveMessage(double collectorId)
    {
        CollectorId = collectorId;
    }

    public TaxCollectorMovementRemoveMessage()
    {
    }

    public override uint MessageId => Id;

    public double CollectorId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(CollectorId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CollectorId = reader.ReadDouble();
    }
}