using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeReplyTaxVendorMessage : Message
{
    public const uint Id = 7870;

    public ExchangeReplyTaxVendorMessage(ulong objectValue, ulong totalTaxValue)
    {
        ObjectValue = objectValue;
        TotalTaxValue = totalTaxValue;
    }

    public ExchangeReplyTaxVendorMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ObjectValue { get; set; }

    public ulong TotalTaxValue { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ObjectValue);
        writer.WriteVarULong(TotalTaxValue);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectValue = reader.ReadVarULong();
        TotalTaxValue = reader.ReadVarULong();
    }
}