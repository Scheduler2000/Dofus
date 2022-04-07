using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeCraftPaymentModifiedMessage : Message
{
    public const uint Id = 8641;

    public ExchangeCraftPaymentModifiedMessage(ulong goldSum)
    {
        GoldSum = goldSum;
    }

    public ExchangeCraftPaymentModifiedMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong GoldSum { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(GoldSum);
    }

    public override void Deserialize(IDataReader reader)
    {
        GoldSum = reader.ReadVarULong();
    }
}