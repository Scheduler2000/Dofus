using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHousePriceMessage : Message
{
    public const uint Id = 8992;

    public ExchangeBidHousePriceMessage(ushort genId)
    {
        GenId = genId;
    }

    public ExchangeBidHousePriceMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort GenId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(GenId);
    }

    public override void Deserialize(IDataReader reader)
    {
        GenId = reader.ReadVarUShort();
    }
}