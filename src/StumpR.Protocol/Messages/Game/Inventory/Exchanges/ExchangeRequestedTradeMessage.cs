using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
{
    public new const uint Id = 9612;

    public ExchangeRequestedTradeMessage(sbyte exchangeType, ulong source, ulong target)
    {
        ExchangeType = exchangeType;
        Source = source;
        Target = target;
    }

    public ExchangeRequestedTradeMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Source { get; set; }

    public ulong Target { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Source);
        writer.WriteVarULong(Target);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Source = reader.ReadVarULong();
        Target = reader.ReadVarULong();
    }
}