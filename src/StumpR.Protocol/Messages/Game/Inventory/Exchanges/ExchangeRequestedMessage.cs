using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeRequestedMessage : Message
{
    public const uint Id = 5525;

    public ExchangeRequestedMessage(sbyte exchangeType)
    {
        ExchangeType = exchangeType;
    }

    public ExchangeRequestedMessage()
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