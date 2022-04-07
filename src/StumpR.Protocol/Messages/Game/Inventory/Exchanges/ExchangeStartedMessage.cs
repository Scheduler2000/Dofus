using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartedMessage : Message
{
    public const uint Id = 8540;

    public ExchangeStartedMessage(sbyte exchangeType)
    {
        ExchangeType = exchangeType;
    }

    public ExchangeStartedMessage()
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