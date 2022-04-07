using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangePlayerRequestMessage : ExchangeRequestMessage
{
    public new const uint Id = 2400;

    public ExchangePlayerRequestMessage(sbyte exchangeType, ulong target)
    {
        ExchangeType = exchangeType;
        Target = target;
    }

    public ExchangePlayerRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Target { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Target);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Target = reader.ReadVarULong();
    }
}