using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeCraftPaymentModificationRequestMessage : Message
{
    public const uint Id = 5785;

    public ExchangeCraftPaymentModificationRequestMessage(ulong quantity)
    {
        Quantity = quantity;
    }

    public ExchangeCraftPaymentModificationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        Quantity = reader.ReadVarULong();
    }
}