using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectMoveKamaMessage : Message
{
    public const uint Id = 427;

    public ExchangeObjectMoveKamaMessage(long quantity)
    {
        Quantity = quantity;
    }

    public ExchangeObjectMoveKamaMessage()
    {
    }

    public override uint MessageId => Id;

    public long Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarLong(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        Quantity = reader.ReadVarLong();
    }
}