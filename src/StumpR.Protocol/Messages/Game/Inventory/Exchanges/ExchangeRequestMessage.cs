using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeRequestMessage : Message
{
    public const uint Id = 289;

    public ExchangeRequestMessage(sbyte exchangeType)
    {
        ExchangeType = exchangeType;
    }

    public ExchangeRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ExchangeType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(ExchangeType);
    }

    public override void Deserialize(IDataReader reader)
    {
        ExchangeType = reader.ReadSByte();
    }
}